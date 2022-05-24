# Cornucopias Mint BlackOps Operation

# Configuration File Example
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },

  "TwoCaptcha": {
    "Key": "<KEYCAPTCHA>"
  },
  "ReCaptcha": {
    "Key": "6Lfn_SwdAAAAAH7Zsvlwpm3x5IGN_nxizvMzA2dq" // StaticKey For Cornucopias
  },
  "Cornucopias": {
    "Email": "<EMAIL>",
    "Password": "<PASSWORD>",
    "Token": "<Bearer TOKEN>" // Optional to avoid login
    "UserId": "<UserID>" // Optional to avoid login
  },
  "SendAda": {
    "Wallet":  "Wallet01"
  }
}
```
# Cornucopias Flow

1 - POST https://mapapi.cornucopias.io/api/SendMessage/LoginUserCommand
Do the login and reply with userId and access token ( bearer Token )

### Request Example:
```json
{
    "$type": "Cornucopias.AssetPortal.Messages.Commands.LoginUserCommand, Cornucopias.AssetPortal.Messages",
    "Email": "<User>",
    "Password": "<Password>",
    "RecaptchaResponse": "03AGdBq27kM4g2qgCXt_FvuN1gEjkane7C7x7leZH6jOTs3k62RynXPeg3WhpQzUo9WJhNJzbxnMmh17etT4Uc4SAA0gUz8DBH-qnH-RT2TCms5XPAkQ6u65B5ER-7ova7XZHN-j68bXlxw070QFH4i9igvg3h3GdRvRi0a9eLz07V4OVi6C-Ydv53xg9LKKUlsXrxr9qDtXht58uoHo_t5av_ygVEQsoVgydjfQ0nwG65WgVQYXAoCgDp2W12kqCAIF9z8IfIlR2g3xx0kHs39J-WF2n0qUyaB4W7Wge2h6RCf644GgVA344AdwICVAqxIuSAXzLDJs53KkkNmqB3V5m43ku7G_ghfkEy9DzOIilz6OiDfdLFep3ji4xHkRM4Cl0nwZU7ysnCPWOokAq_0Uq0NYo2Wxh4vcmjRIqb5Z16B27b8hUMJQm4GUE3yYS8kB8RbpSPGbS5hQt-8mfhhys21lWI-SFhEqR35Y2s9ZtuY7rPdZ3tdlY"
}
```

### Response Example:
```json
{
    "$type": "Cornucopias.AssetPortal.Messages.MessageWrappers.ServerResponse`1[[Cornucopias.AssetPortal.Messages.Commands.LoginUserResponse, Cornucopias.AssetPortal.Messages]], Cornucopias.AssetPortal.Messages",
    "Response": {
        "$type": "Cornucopias.AssetPortal.Messages.Commands.LoginUserResponse, Cornucopias.AssetPortal.Messages",
        "RefreshToken": {
            "$type": "Cornucopias.AssetPortal.CommonPublic.SharedData.SharedRefreshToken, Cornucopias.AssetPortal.CommonPublic",
            "Id": "3e51f802-7348-4ae1-8220-d392a2a6b8f1",
            "Token": "JMcPs1nicgYoUm4HvK0aYsaAyg5eTN",
            "RowVersion": {
                "$type": "System.Byte[], System.Private.CoreLib",
                "$value": "AAAAAAAFh4Q="
            }
        },
        "AccessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjNkNjIxYjdhLWNjYWItNDJkNC05M2NmLWI2MTMwMjI1NzEzYSIsImVtYWlsIjoiUG9pblRlZEBnb2ZvcmVtYWlsLm1lIiwicm9sZSI6WyJDdXN0b21lciJdLCJuYmYiOjE2NTMzMjc0NTIsImV4cCI6MTY1MzkzMjI1MiwiaWF0IjoxNjUzMzI3NDUyfQ.NslJvc2EgBZ68wsl3bOu7bese8BeIOb0GMFi4B1rxI0",
        "DiscordStatus": {
            "$type": "Cornucopias.AssetPortal.Messages.ResponseObjects.UserDiscordStatus, Cornucopias.AssetPortal.Messages",
            "UserId": "3d621b7a-ccab-42d4-93cf-b6130225713a",
            "DiscordUsername": "PoinTed#1497",
            "IsDiscordUsernameVerified": true,
            "DiscordRoles": {
                "$type": "System.Collections.Generic.List`1[[Cornucopias.AssetPortal.Messages.ResponseObjects.UserDiscordStatus+DiscordRole, Cornucopias.AssetPortal.Messages]], System.Private.CoreLib",
                "$values": [
                    {
                        "$type": "Cornucopias.AssetPortal.Messages.ResponseObjects.UserDiscordStatus+DiscordRole, Cornucopias.AssetPortal.Messages",
                        "Id": 829374949587419137,
                        "Name": "@everyone"
                    },
                    {
                        "$type": "Cornucopias.AssetPortal.Messages.ResponseObjects.UserDiscordStatus+DiscordRole, Cornucopias.AssetPortal.Messages",
                        "Id": 897523228266868766,
                        "Name": "Cornucopians"
                    },
                    {
                        "$type": "Cornucopias.AssetPortal.Messages.ResponseObjects.UserDiscordStatus+DiscordRole, Cornucopias.AssetPortal.Messages",
                        "Id": 953049253134090260,
                        "Name": "Bubblejett Holder"
                    }
                ]
            },
            "VerificationCode": "395028"
        }
    },
    "Reasons": {
        "$type": "System.Collections.Generic.List`1[[FluentResults.IReason, FluentResults]], System.Private.CoreLib",
        "$values": []
    },
    "HttpStatusCode": 200
}
```

2 - POST https://mapapi.cornucopias.io/api/SendMessage/GetStandaloneNftSaleDataRequest
Check and reply with active sales

### Request Example:
```json
{"$type":"Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataRequest, Cornucopias.AssetPortal.Messages"}
```

### Response Example:
```json
{
    "$type": "Cornucopias.AssetPortal.Messages.MessageWrappers.ServerResponse`1[[Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataResponse, Cornucopias.AssetPortal.Messages]], Cornucopias.AssetPortal.Messages",
    "Response": {
        "$type": "Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataResponse, Cornucopias.AssetPortal.Messages",
        "SalesItemGroups": {
            "$type": "System.Collections.Generic.List`1[[Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataResponse+SalesItemGroupDto, Cornucopias.AssetPortal.Messages]], System.Private.CoreLib",
            "$values": [
                {
                    "$type": "Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataResponse+SalesItemGroupDto, Cornucopias.AssetPortal.Messages",
                    "Id": "cc64374d-0fae-4c3e-a4bb-1cf31d21fe8f",
                    "Name": "NFT2Tree",
                    "CurrencyId": "ADA",
                    "DiscordRoleRequirementId": 1,
                    "IsRestrictedToAdmins": false,
                    "SalesItemGroupDiscordRoles": {
                        "$type": "System.Collections.Generic.List`1[[Cornucopias.AssetPortal.CommonPublic.DataInterfaces.Entities.ISalesItemGroupDiscordRole, Cornucopias.AssetPortal.CommonPublic]], System.Private.CoreLib",
                        "$values": [
                            {
                                "$type": "Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataResponse+SalesItemGroupDiscordRoleDto, Cornucopias.AssetPortal.Messages",
                                "DiscordRoleId": 877255811380969542,
                                "DiscordRole": {
                                    "$type": "Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataResponse+DiscordRoleDto, Cornucopias.AssetPortal.Messages",
                                    "Name": "OG | Old Guard",
                                    "Id": 877255811380969542
                                }
                            }
                        ]
                    },
                    "State": 2,
                    "QuotaPerUser": 1,
                    "QuotaPerOrder": 1,
                    "StandaloneNftDefinition": {
                        "$type": "Cornucopias.AssetPortal.Messages.Requests.GetStandaloneNftSaleDataResponse+StandaloneNftDefinitionDto, Cornucopias.AssetPortal.Messages",
                        "Id": "b02b8b18-ac28-4746-a6e5-aeb7c4ec531c",
                        "Name": "NFT2Tree",
                        "NftReferencePrefix": "NFT2TREE",
                        "Quota": 10000,
                        "MediaList": {
                            "$type": "System.Collections.Generic.List`1[[Cornucopias.AssetPortal.CommonPublic.SharedData.NftMediaDto, Cornucopias.AssetPortal.CommonPublic]], System.Private.CoreLib",
                            "$values": [
                                {
                                    "$type": "Cornucopias.AssetPortal.CommonPublic.SharedData.NftMediaDto, Cornucopias.AssetPortal.CommonPublic",
                                    "StandaloneNftDefinitionId": "b02b8b18-ac28-4746-a6e5-aeb7c4ec531c",
                                    "StandaloneNftDefinitionRarityId": null,
                                    "NftMediaVariants": {
                                        "$type": "System.Collections.Generic.List`1[[Cornucopias.AssetPortal.CommonPublic.SharedData.NftMediaVariantDto, Cornucopias.AssetPortal.CommonPublic]], System.Private.CoreLib",
                                        "$values": [
                                            {
                                                "$type": "Cornucopias.AssetPortal.CommonPublic.SharedData.NftMediaVariantDto, Cornucopias.AssetPortal.CommonPublic",
                                                "MediaSizeId": 2,
                                                "BlobUrl": "nft-media/b02b8b18-ac28-4746-a6e5-aeb7c4ec531c/fe4be4a6-551d-4ee1-888c-006b272abe21/1e94902f-9cf6-490d-838f-a6bb1e369a59.jpg",
                                                "MimeType": "image/jpeg"
                                            },
                                            {
                                                "$type": "Cornucopias.AssetPortal.CommonPublic.SharedData.NftMediaVariantDto, Cornucopias.AssetPortal.CommonPublic",
                                                "MediaSizeId": 1,
                                                "BlobUrl": "nft-media/b02b8b18-ac28-4746-a6e5-aeb7c4ec531c/fe4be4a6-551d-4ee1-888c-006b272abe21/2750574e-e5fd-4b8b-9ec1-c065fa37453a.jpg",
                                                "MimeType": "image/jpeg"
                                            },
                                            {
                                                "$type": "Cornucopias.AssetPortal.CommonPublic.SharedData.NftMediaVariantDto, Cornucopias.AssetPortal.CommonPublic",
                                                "MediaSizeId": 3,
                                                "BlobUrl": "nft-media/b02b8b18-ac28-4746-a6e5-aeb7c4ec531c/fe4be4a6-551d-4ee1-888c-006b272abe21/a073fc25-0192-4659-89a3-a4c8865f1aff.jpg",
                                                "MimeType": "image/jpeg"
                                            }
                                        ]
                                    },
                                    "IsDefault": true,
                                    "MediaTypeId": 1
                                }
                            ]
                        },
                        "CardanoPolicyClosingDateUtc": "2022-06-30T00:00:00"
                    },
                    "NumberAvailable": 64,
                    "TotalNumberGenerated": 480,
                    "TotalQuota": 10000,
                    "Price": 15,
                    "SaleDisplayState": 2,
                    "RowVersion": {
                        "$type": "System.Byte[], System.Private.CoreLib",
                        "$value": "AAAAAAACfoM="
                    },
                    "MaxItemRowVersion": {
                        "$type": "System.Byte[], System.Private.CoreLib",
                        "$value": "AAAAAAACny8="
                    }
                }
            ]
        }
    },
    "Reasons": {
        "$type": "System.Collections.Generic.List`1[[FluentResults.IReason, FluentResults]], System.Private.CoreLib",
        "$values": []
    },
    "HttpStatusCode": 200
}
```

3 - POST https://mapapi.cornucopias.io/api/SendMessage/CheckCanPlaceInstantOrderRequest
Check if the specific user can buy and reply with address and other metadata

### Request Example:
```json
{
    "$type": "Cornucopias.AssetPortal.Messages.Requests.CheckCanPlaceInstantOrderRequest, Cornucopias.AssetPortal.Messages",
    "UserId": "2a2bf27f-dc2c-48d5-abce-f9a3e85be581",
    "OrderInfo": {
        "$type": "Cornucopias.AssetPortal.Messages.RequestObjects.PlaceOrderInfo+ReserveAvailableItemsOnSalesItemGroup, Cornucopias.AssetPortal.Messages",
        "SalesItemGroupId": "cc64374d-0fae-4c3e-a4bb-1cf31d21fe8f",
        "ReservationQuantity": 1
    }
}
```

### Response Example:
```json
{
    "$type": "Cornucopias.AssetPortal.Messages.MessageWrappers.ServerResponse`1[[Cornucopias.AssetPortal.Messages.Requests.CheckCanPlaceInstantOrderResponse, Cornucopias.AssetPortal.Messages]], Cornucopias.AssetPortal.Messages",
    "Response": {
        "$type": "Cornucopias.AssetPortal.Messages.Requests.CheckCanPlaceInstantOrderResponse, Cornucopias.AssetPortal.Messages",
        "PaymentAddressId": "e0c2708e-ccaf-4c18-9e78-c63b65649562",
        "AdaPaymentAddress": "addr1qxrtz7k3q0tkpthe9ujpdqfeq5zc8w64mrgdf77ljx9ua2tpu4jjdkp65eu2lef742qta6vr44yrafhr6z5sr8zt7zlstvl6gy"
    },
    "Reasons": {
        "$type": "System.Collections.Generic.List`1[[FluentResults.IReason, FluentResults]], System.Private.CoreLib",
        "$values": []
    },
    "HttpStatusCode": 200
}
```

4 - POST https://cardano.super.power/submit
Integration with ppiloto webapi to make the transaction

### Request Example:
```json
{
    "wallet": "Wallet01",
    "amount": "2a2bf27f-dc2c-48d5-abce-f9a3e85be581",
    "destination": "addrasdalkdjalsdjkadpoasdpoajdaspsdjpasda809d8798ad987a6d89a6da",
}
```

### Response Example:
```json
{
    "tx":{
        "txHash":"AGGHG768787AA8789A87A98A79A8A7987A987A",
        "signedTx":"AGGHG768787AA8789A87A98A79A8A7987A987A",
    }
}
```

5 - POST https://mapapi.cornucopias.io/api/SendMessage/EnterOrderQueueCommand
Enter in queue and send txId and txSigned to enter.

### Request Example:
```json
{
    "$type": "Cornucopias.AssetPortal.Messages.Commands.OrderQueue.EnterOrderQueueCommand, Cornucopias.AssetPortal.Messages",
    "UserId": "04ae1680-fdc1-49f0-b8e1-eab33fae4299",
    "OrderInfo": {
        "$type": "Cornucopias.AssetPortal.Messages.RequestObjects.PlaceOrderInfo+ReserveAvailableItemsOnSalesItemGroup, Cornucopias.AssetPortal.Messages",
        "SalesItemGroupId": "cc64374d-0fae-4c3e-a4bb-1cf31d21fe8f",
        "ReservationQuantity": 1
    },
    "PaymentAddressId": "e0c2708e-ccaf-4c18-9e78-c63b65649562",
    "TransactionId": "2B463B3F9B74B0A8558A4161F1632790800A77CFD87FA485E9B02289DE0C1586",
    "SignedTransactionCborHex": "83A400818258201B3140E075FC4DFA0A96A2AAE44AFCF7F7B982A77CFBB0A67A8730083AD3942F0201828258390186B17AD103D760AEF92F24168139050583BB55D8D0D4FBDF918BCEA961E56526D83AA678AFE53EAA80BEE983AD483EA6E3D0A9019C4BF0BF1A0112A88082583901B7ECB676A1826B060CA7FE03135CBB0CAF03C02BBB36F2EE9392F822E528E3FAFC180CBD8931E9A564A9D29AB7F25F7836E9360F12D9669C1A0E66597B021A00029D85031A03AA6F23A10081825820CE91FA730BEC374BBAF2D2D07C022B4CEF87B8BBDB2CB52D71D192B86892589358401FAA1C18652BABD3605E17870EA60D3A426F4CEDEA317B1B7035B920C90C6F0B8FDF2DEE751A59AF0B366143C30209E9BE857068EF79B2AE92D043626BC99D05F6"
}
```


