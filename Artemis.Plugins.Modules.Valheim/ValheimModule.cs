using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.Plugins.Modules.Valheim.DataModels;
using SkiaSharp;

namespace Artemis.Plugins.Modules.Valheim
{
    public class ValheimModule : ProfileModule<ValheimDataModel>
    {
        private readonly IWebServerService _webServerService;

        public ValheimModule(IWebServerService webServerService)
        {
            _webServerService = webServerService;
        }

        public override void Enable()
        {
            DisplayName = "Valheim";
            DisplayIcon = "ToyBrickPlus";
            DefaultPriorityCategory = ModulePriorityCategory.Application;

            _webServerService.AddJsonEndPoint<PlayerData>(this, "player", p => DataModel.Player = p);
            _webServerService.AddJsonEndPoint<Enviroment>(this, "environment", e => DataModel.Environment = e);
        }

        public override void Disable()
        {
        }

        public override void ModuleActivated(bool isOverride)
        {
        }

        public override void ModuleDeactivated(bool isOverride)
        {
        }

        public override void Update(double deltaTime)
        {
        }

        public override void Render(double deltaTime, ArtemisSurface surface, SKCanvas canvas, SKImageInfo canvasInfo)
        {
        }
    }
}