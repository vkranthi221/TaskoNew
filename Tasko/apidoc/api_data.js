define({ "api": [
  {
    "type": "post",
    "url": "c1/GetOrderDetails",
    "title": "Get Order details",
    "name": "GetOrderDetails",
    "group": "Customer",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "orderId",
            "description": "<p>Order Id.</p>"
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "firstname",
            "description": "<p>Firstname of the User.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "lastname",
            "description": "<p>Lastname of the User.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": {\n    \"__type\": \"Order:#Tasko.Model\",\n    \"Comments\": \"\",\n    \"CustomerId\": \"692BD435A5173E42916438F889F5DA08\",\n    \"CustomerName\": \"Shivaji\",\n    \"DestinationAddress\": {\n      \"Address\": \"plot no 404, BaghyaNagar\",\n      \"AddressId\": \"8397A91B6E997F438A9D4D9D49D3E12A\",\n      \"City\": \"Hyderabad\",\n      \"Country\": \"India\",\n      \"Lattitude\": \"40\",\n      \"Locality\": \"HMT HILLS\",\n      \"Longitude\": \"600\",\n      \"Pincode\": \"500072\",\n      \"State\": \"Telangana\"\n    },\n    \"Location\": \"kphb\",\n    \"OrderId\": \"TASKO1000\",\n    \"OrderStatus\": \"Requested\",\n    \"OrderStatusId\": 1,\n    \"RequestedDate\": \"2016-06-29 22:49:47\",\n    \"ServiceId\": \"9661D3C7E345B747BBE62DEA76F00B82\",\n    \"ServiceName\": \"Electrician\",\n    \"SourceAddress\": {\n      \"Address\": \"plot no 101, vivekanandaNagar\",\n      \"AddressId\": \"36F6A0E2C85F7D46AF68C4EB73148B2A\",\n      \"City\": \"Hyderabad\",\n      \"Country\": \"India\",\n      \"Lattitude\": \"10\",\n      \"Locality\": \"kphb\",\n      \"Longitude\": \"200\",\n      \"Pincode\": \"500081\",\n      \"State\": \"Telangana\"\n    },\n    \"VendorId\": \"C3A4A364DA1DE542BA70FBAD2435D571\",\n    \"VendorName\": \"chandra\",\n    \"VendorServiceId\": \"CD2CA27D52CE5E4D8E897D53CC4379CB\"\n  },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "OrderIdNotFound",
            "description": "<p>The Order id was not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Order not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./apidoc/main.js",
    "group": "D__Chandu_Projects_TaskoGitHub_Tasko_apidoc_main_js",
    "groupTitle": "D__Chandu_Projects_TaskoGitHub_Tasko_apidoc_main_js",
    "name": ""
  },
  {
    "type": "post",
    "url": "v1/GetVendorDetails",
    "title": "Get Vendor details",
    "name": "GetVendorDetails",
    "group": "Vendor",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": {\n    \"__type\": \"Vendor:#Tasko.Model\",\n    \"Address\": \"KPHB,HMT Hills\",\n    \"BaseRate\": 100,\n    \"CallsToCustomerCare\": 123,\n    \"DataConsumption\": 10,\n    \"EmailAddress\": \"sree@gmail.com\",\n    \"Id\": \"05B3274A2E6EC94D8C0292293823C122\",\n    \"IsVendorLive\": false,\n    \"IsVendorVerified\": true,\n    \"MobileNumber\": \"9848022669\",\n    \"Name\": \"Steve\",\n    \"NoOfEmployees\": 10,\n    \"UserName\": \"sree123\"\n  },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "VendorIdNotFound",
            "description": "<p>The Vendor id is invalid or was not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Vendor not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  }
] });
