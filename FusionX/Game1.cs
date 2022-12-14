using System;
using System.IO;
using System.Runtime.InteropServices;
using FusionX.Application;
using FusionX.Services;
using FusionX.Sprites;
using Joveler.Compression.ZLib;
using Microsoft.Xna.Framework;
#if !WINDOWS_PHONE
//using Microsoft.Xna.Framework.GamerServices;
#endif

//01
#if WINDOWS_PHONE
using Microsoft.Advertising.Mobile.Xna;
#endif
//01END 

namespace FusionX
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatchEffect spriteBatch;
//02
#if WINDOWS_PHONE
        public static AdGameComponent adGameComponent;
#endif
//02END
        public bool bPreviousActive;
        public bool bInitialActivation;

        CRunApp application;
#if !WINDOWS_PHONE
        //public GamerServicesComponent gamerServices;
#endif
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
//03
#if WINDOWS_PHONE
            AdGameComponent.Initialize(this, "test_client");
            adGameComponent = AdGameComponent.Current;
            Components.Add(adGameComponent);
#endif
//03END
#if WINDOWS_PHONE
            Microsoft.Phone.Shell.PhoneApplicationService.Current.Activated +=
                new EventHandler<Microsoft.Phone.Shell.ActivatedEventArgs>(GameActivated);
            Microsoft.Phone.Shell.PhoneApplicationService.Current.Deactivated +=
                new EventHandler<Microsoft.Phone.Shell.DeactivatedEventArgs>(GameDeactivated);
#endif
            bPreviousActive = false;
            bInitialActivation = true;
        }
#if WINDOWS_PHONE
        void GameActivated(object sender, Microsoft.Phone.Shell.ActivatedEventArgs e)
        {
            if (application != null && application.run != null)
            {
                if (application.XNAObject != null)
                {
                    application.run.callEventExtension(application.XNAObject, 3, 0);
                }
                application.run.resume();
            }
        }

        void GameDeactivated(object sender, Microsoft.Phone.Shell.DeactivatedEventArgs e)
        {
            if (application != null && application.run != null)
            {
                if (application.XNAObject != null)
                {
                    application.run.callEventExtension(application.XNAObject, 2, 0);
                }
                application.run.pause();
            }
        }
#endif

        protected override void Initialize()
        {
#if !WINDOWS_PHONE
            //GamerServicesDispatcher.WindowHandle = Window.Handle;
            //GamerServicesDispatcher.Initialize(Services);
#endif
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatchEffect(Content, GraphicsDevice);
            IsMouseVisible = true;
            
            string arch = null;
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    arch = "x86";
                    break;
                case Architecture.X64:
                    arch = "x64";
                    break;
                case Architecture.Arm:
                    arch = "armhf";
                    break;
                case Architecture.Arm64:
                    arch = "arm64";
                    break;
            }
            string libPath = Path.Combine(arch, "zlibwapi.dll");
            

            if (!File.Exists(libPath))
                throw new PlatformNotSupportedException($"Unable to find native library [{libPath}].");

            ZLibInit.GlobalInit(libPath);
            String libraryFile = Path.Combine(Path.GetDirectoryName(typeof(Game1).Assembly.Location), "x64",
                "CTFAK-Native.dll");
            NativeLib.LoadLibrary(libraryFile);
            
            
            //BinaryRead.Data cca = Content.Load<BinaryRead.Data>("Application");

            var args = Environment.GetCommandLineArgs();
            string file = "";
            if (args.Length < 2)
            {
                file = "Application.ccn";
            }
            else file = args[1];
            if (!File.Exists(file))
            {
                Environment.Exit(-1);
            }
            CFile cfile = new CFile(new FileStream(file,FileMode.Open));//cca.data);
            application = new CRunApp(this, cfile);
            if (application.load())
            {
                application.startApplication();
            }
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            // Activation / Deactivation of the application
            if (bPreviousActive != IsActive)
            {
                bPreviousActive=IsActive;
                if (bInitialActivation == false)
                {
                    if (application.run != null)
                    {
                        if (IsActive)
                            application.run.resume();
                        else
                            application.run.pause();
                    }
                }
                else
                {
                    bInitialActivation = false;
                }
            }

            double time = gameTime.TotalGameTime.TotalMilliseconds;
            if (application.playApplication(false, time) == false)
            {
                this.Exit();
            }
#if !WINDOWS_PHONE
            //if (GamerServicesDispatcher.IsInitialized)
            {
                //GamerServicesDispatcher.Update();
            }
#endif
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            double time = gameTime.TotalGameTime.TotalMilliseconds;

            application.draw();

            base.Draw(gameTime);
        }
    }
}
