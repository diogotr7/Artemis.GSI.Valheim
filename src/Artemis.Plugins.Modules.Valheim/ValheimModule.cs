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
            DisplayIcon = "Valheim.svg";
            DefaultPriorityCategory = ModulePriorityCategory.Application;
            ActivationRequirements.Add(new ProcessActivationRequirement("valheim"));

            _webServerService.AddJsonEndPoint<PlayerData>(this, "player", p =>
            {
                DataModel.Player = p;
            });
            _webServerService.AddJsonEndPoint<Enviroment>(this, "environment", e =>
            {
                DataModel.Environment = e;
            });
            _webServerService.AddStringEndPoint(this, "teleport", _ =>
            {
                DataModel.Teleport.Trigger();
            });
            _webServerService.AddJsonEndPoint<SkillLevelUpEventArgs>(this, "levelUp", e =>
            {
                DataModel.SkillLevelUp.Trigger(e);
            });
            _webServerService.AddStringEndPoint(this, "forsakenActivated", _ =>
            {
                DataModel.ForsakenActivated.Trigger();
            });
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

        public override void Render(double deltaTime, SKCanvas canvas, SKImageInfo canvasInfo)
        {
        }
    }
}