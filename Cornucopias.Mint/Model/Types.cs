using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public static class Types
    {
        public static string LOGIN_COMMAND_TYPE = "Cornucopias.AssetPortal.Messages.Commands.LoginUserCommand, Cornucopias.AssetPortal.Messages";
        public static string GET_DISCORD_VERIFICATION_TYPE = "Cornucopias.AssetPortal.Messages.Requests.Discord.GetDiscordVerificationStatusRequest, Cornucopias.AssetPortal.Messages";
        public static string NFT_SALE_DATA_TYPE = "Cornucopias.AssetPortal.Messages.MessageWrappers.ServerResponse`1[[Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataResponse, Cornucopias.AssetPortal.Messages]], Cornucopias.AssetPortal.Messages";
        public static string CHECK_CAN_PLACE_ORDER_TYPE = "Cornucopias.AssetPortal.Messages.Requests.CheckCanPlaceInstantOrderRequest, Cornucopias.AssetPortal.Messages";
        public static string ORDER_TYPE = "Cornucopias.AssetPortal.Messages.RequestObjects.PlaceOrderInfo+ReserveAvailableItemsOnSalesItemGroup, Cornucopias.AssetPortal.Messages";
        public static string PLACE_ORDER_TYPE = "Cornucopias.AssetPortal.Messages.RequestObjects.PlaceOrderInfo+ReserveAvailableItemsOnSalesItemGroup, Cornucopias.AssetPortal.Messages";
        public static string ENTER_QUEUE_TYPE = "Cornucopias.AssetPortal.Messages.Commands.OrderQueue.EnterOrderQueueCommand, Cornucopias.AssetPortal.Messages";
    }
}
