define({ "api": [
  {
    "type": "post",
    "url": "a1/AddPayment",
    "title": "Add Payment",
    "name": "AddPayment",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Payment",
            "optional": false,
            "field": "payment",
            "description": "<p>Payment details.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n    \"payment\": {\n    \"VendorId\": \"F9756A47F455F64DAD4B24E49A257188\",\n    \"DueDate\": \"23/6/2016\",\n    \"PaidDate\": \"10/7/2016\",\n    \"Amount\": 300,\n    \"Status\": \"Pending\",\n    \"Description\": \"OutStanding Charge\",\n    \"PayForMonth\": \"June 2016\"\n    }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/AddService",
    "title": "Add Service",
    "name": "AddService",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Service",
            "optional": false,
            "field": "service",
            "description": "<p>Service Info.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"service\":\n  {   \n    \"Name\": \"AC Service\",\n    \"ParentServiceId\": \"\",\n    \"ImageUrl\": \"http://api.tasko.in/serviceimages/ac_services.png\",\n    \"Status\": \"0\"\n  }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/AddUser",
    "title": "Add Admin User",
    "name": "AddUser",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>user id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Token code got from login API\" ,\n  \"User_Id\": \"User id\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "userName",
            "description": "<p>user name of customer.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "password",
            "description": "<p>password.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n user:\n           {\n            \"__type\": \"User:#Tasko.Model\",\n            \"EmailId\": \"testuser@testuser.com\",\n            \"Id\": \"E51DF58EF04A1947BE85BB5B04AC94A9\",\n            \"IsActive\": true,\n            \"IsAdmin\": true,\n            \"JoinedDate\": \"2016-07-13 15:13:01\",\n            \"MobileNumber\": \"9898987876\",\n            \"Name\": \"testuser\",\n            \"PassWord\": \"testuser\",\n            \"UserName\": \"testuser\"\n          }\n          }",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": {\n   \"__type\": \"LoginInfo:#Tasko.Model\",\n   \"TokenId\": \"B282108B71974748876F5BAC53A93F\",\n   \"UserId\": \"E51DF58EF04A1947BE85BB5B04AC94A9\"\n },\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_CREDENTIALS",
            "description": "<p>Invalid credentials.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Data\": \"\",\n     \"Error\": true,\n     \"Message\": \"User Name Exists\",\n     \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetUserDetails",
    "title": "Get user details",
    "name": "AddUser",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>user id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Token code got from login API\" ,\n  \"User_Id\": \"User id\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "userId",
            "description": "<p>user id of admin user.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "\n{\n  \"userId\": \"E51DF58EF04A1947BE85BB5B04AC94A9\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": {\n   \"__type\": \"User:#Tasko.Model\",\n   \"EmailId\": \"kranthi@kr.com\",\n   \"Id\": \"E51DF58EF04A1947BE85BB5B04AC94A9\",\n   \"IsActive\": true,\n   \"IsAdmin\": true,\n   \"JoinedDate\": \"2016-07-13 15:13:01\",\n   \"MobileNumber\": \"9898987876\",\n   \"Name\": \"kranthi\",\n   \"PassWord\": \"kranthi\",\n   \"UserName\": \"kranthi\"\n },\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_CREDENTIALS",
            "description": "<p>Invalid credentials.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"User not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/AddVendor",
    "title": "Add Vendor",
    "name": "AddVendor",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendor",
            "description": "<p>Vendor .</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"vendor\": {\n                        \"AddressDetails\": {\n                          \"Address\": \"plot no 404, BaghyaNagar\",\n                          \"AddressId\": null,\n                          \"AddressType\":\"Home\",\n                          \"City\": \"Hyderabad\",\n                          \"Country\": \"India\",\n                          \"Lattitude\": \"40\",\n                          \"Locality\": \"HMT HILLS\",\n                          \"Longitude\": \"600\",\n                          \"Pincode\": \"500072\",\n                          \"State\": \"Hyderabad\"\n                        },\n                        \"BaseRate\": 100,\n                        \"DateOfBirth\": \"7/7/2016 2:12:55 PM\",\n                        \"EmailAddress\": \"sree@gmail.com\",\n                        \"Gender\": 0,\n                        \"IsVendorLive\": false,\n                        \"IsVendorVerified\": true,\n                        \"MobileNumber\": \"9985466195\",\n                        \"Name\": \"srikanth3\",\n                        \"Experience\":\"1\",\n                        \"VendorAlsoKnownAs\":\"srikanth\",\n                        \"NoOfEmployees\": 10,\n                        \"Password\": \"123456\",\n                        \"Photo\": \"test photo\",\n                        \"UserName\": \"srikanth3\",\n                        \"VendorDetails\": {\n                          \"MonthlyCharge\": \"1000\",\n                          \"IsBlocked\": \"false\",\n                          \"IsPowerSeller\": \"true\",\n                          \"AreOrdersBlocked\": \"false\"\n                        },\n                        \"VendorServices\": [\n                                    {\n                                      \"ServiceId\": \"226AC0D8D240344294A5D1FC4DC96273\"\n                                    },\n                                    {\n                                     \"ServiceId\": \"B42A577C337BEB4988E8E02200F28965\"  \n                                    }\n                                 ]\n                      }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n  \"Data\":\"D519EDD9B0713B4699E75C0D24F54370\" ,\n         \"Error\": false,\n         \"Message\": \"Success\",\n         \"Status\": 200\n}",
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
            "field": "ADD_VENDOR_FAILED",
            "description": "<p>Error adding vendor.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Error adding vendor.\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/DeleteService",
    "title": "Delete Service",
    "name": "DeleteService",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "serviceId",
            "description": "<p>Service Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"serviceId\":\"54CFD4A388C27046918399822EAA7458\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": null,\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "SERVICE_IN_USE",
            "description": "<p>Unable to delete the Service as it is in Use.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Unable to delete the Service as it is in Use\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/DeleteUser",
    "title": "Delete user",
    "name": "DeleteUser",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>user id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Token code got from login API\" ,\n  \"User_Id\": \"User id\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "userId",
            "description": "<p>user id of admin user.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "\n{\n  \"userId\": \"E51DF58EF04A1947BE85BB5B04AC94A9\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_CREDENTIALS",
            "description": "<p>Invalid credentials.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Fail\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/DisableService",
    "title": "Disable Service",
    "name": "DisableService",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "serviceId",
            "description": "<p>Service Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "short",
            "optional": false,
            "field": "status",
            "description": "<p>status {0 - Active; 1 - Disable}.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"serviceId\":\"54CFD4A388C27046918399822EAA7458\",\n  \"status\":\"1\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetAllComplaints",
    "title": "Get All Complaints",
    "name": "GetAllComplaints",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"GcmUser:#Tasko.Model\",\n              \"CustomerId\": \"F3E6D9CBF8EF6A4289E1FC3509076D54\",\n              \"GcmId\": \"995FB41FF15F374398985802AF9E0CD5\",\n              \"GcmRegId\": \"APA91bEvA_MLQBs27lR24U_dEXkBoxL5K5VL5l2BkkVoi_6axHy8tEQvEBLRZ-Vlo4FY9u6S0I5PI5EhshJ-jJ5JjgjYBhExk2kuCVa7cFC1KxNgi6QMpzu6IsClEGbbV2ZvG_-H6DC6\",\n              \"Name\": \"srikanth\",\n              \"VendorId\": null\n            }\n          ],\n          \"Error\": false,\n          \"Message\": \"Success\",\n          \"Status\": 200\n}",
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
            "field": "USERS_NOT_FOUND",
            "description": "<p>Users not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Users not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetAllComplaints",
    "title": "Get All Complaints",
    "name": "GetAllComplaints",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "complaintStatus",
            "description": "<p>Complaint status where 0 refers to all complaints.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n      {\n                  \"complaintStatus\": 1\n                }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"Complaint:#Tasko.Model\",\n              \"ComplaintChats\": null,\n              \"ComplaintId\": \"Complaint#1000\",\n              \"ComplaintStatus\": 0,\n              \"DueDate\": null,\n              \"LoggedDate\": \"2016-07-16 07:16:28\",\n              \"OrderId\": null,\n              \"Title\": \"Test\"\n            }\n          ],\n          \"Error\": false,\n          \"Message\": \"Success\",\n          \"Status\": 200\n}",
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
            "field": "COMPLAINT_NOT_FOUND",
            "description": "<p>Complaints not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Complaints not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetOffileVendorRequests",
    "title": "Gets offline vendor requests for the day",
    "name": "GetAllCustomersByStatus",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n   \"Data\": [\n            {\n              \"__type\": \"OfflineVendorRequest:#Tasko.Model\",\n              \"CustomerName\": \"srikanth test\",\n              \"CustomerPhone\": \"9849345086\",\n              \"Id\": \"4720EA1EEFDEE141AABE38A7E7D3831A\",\n              \"RequestedServiceId\": \"2D0D8369F97C7E4D9757F4F1BF39324C\",\n              \"RequestedServiceName\": \"AC Installation\"\n            },\n            {\n              \"__type\": \"OfflineVendorRequest:#Tasko.Model\",\n              \"CustomerName\": \"Shivaji\",\n              \"CustomerPhone\": \"1234567890\",\n              \"Id\": \"697413385619B943BE380ADFF78EA868\",\n              \"RequestedServiceId\": \"3CB1F934AEE59E4EA6E824B96752FE27\",\n              \"RequestedServiceName\": \"Semi-Automatic Washing Machine Service\"\n            }\n          ],\n          \"Error\": false,\n          \"Message\": \"Success\",\n          \"Status\": 200\n}",
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
            "field": "REQUESTS_NOT_FOUND",
            "description": "<p>No Offline Requests</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"No Offline Requests\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetAllCustomersByStatus",
    "title": "Get all the customers for a specified status. 0 - All, 1- Online, 2- Offline, 3- Blocked",
    "name": "GetAllCustomersByStatus",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "customerStatus",
            "optional": false,
            "field": "customerStatus",
            "description": "<p>0 - All, 1- Online, 2- Offline, 3- Blocked.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n           \"customerStatus\": 0\n          }",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n    \"Data\": [\n        {\n            \"__type\": \"CustomerRating:#Tasko.Model\",\n            \"Comments\": null,\n            \"Courtesy\": 3,\n            \"CustomerId\": null,\n            \"CustomerName\": \"Shivaji\",\n            \"Id\": null,\n            \"OrderId\": \"TASKO1000\",\n            \"OverAllRating\": 2,\n            \"Price\": 1,\n            \"Punctuality\": 2,\n            \"ReviewDate\": null,\n            \"ServiceQuality\": 2,\n            \"VendorId\": null,\n            \"VendorName\": \"chandra\"\n        }\n    ],\n\"Error\": false,\n\"Message\": \"Success\",\n\"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetAllCustomersByStatus",
    "title": "Get All Customers By Status",
    "description": "<p>Get the customers details based on the given status. The possible statuses are 0 - All, 1- Online, 2- Offline, 3- Blocked</p>",
    "name": "GetAllCustomersByStatus",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "customerStatus",
            "optional": false,
            "field": "customerStatus",
            "description": "<p>0 - All, 1- Online, 2- Offline, 3- Blocked.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n           \"customerStatus\": 0\n          }",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n  \"Data\": [\n    {\n      \"__type\": \"Customer:#Tasko.Model\",\n      \"EmailAddress\": \"shivaji@gmail.com\",\n      \"Id\": \"3B456AD997CC9046B4B8F45244B50A57\",\n      \"MobileNumber\": \"1234567890\",\n      \"Name\": \"Shivaji\"\n    },\n    {\n      \"__type\": \"Customer:#Tasko.Model\",\n      \"EmailAddress\": \"shivaji456@gmail.com\",\n      \"Id\": \"41F53C6CE848E843B75FA43A274FD18C\",\n      \"MobileNumber\": \"9876543210\",\n      \"Name\": \"Shivaji456\"\n    },\n  ],\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetAllPaymentsByStatus",
    "title": "Get All Payments",
    "name": "GetAllPaymentsByStatus",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "status",
            "description": "<p>Status {Pending, Completed, ALL}.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example1:",
          "content": "{ \n    \"status\": \"ALL\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    {\n    \"Data\": [\n    {\n        \"__type\": \"Payment:#Tasko.Model\",\n        \"Amount\": 500,\n        \"Description\": \"Monthly Charge\",\n        \"DueDate\": \"2016-06-23\",\n        \"PaidDate\": \"2016-07-07\",\n        \"PayForMonth\": \"May 2016\",\n        \"PaymentId\": \"TASKOPAY1000\",\n        \"Status\": \"Completed\",\n        \"VendorId\": \"682D49C154DB16499DA55BF1D50930FF\",\n        \"VendorName\": \"Srikanth\"\n    },\n    {\n        \"__type\": \"Payment:#Tasko.Model\",\n        \"Amount\": 300,\n        \"Description\": \"OutStanding Charge\",\n        \"DueDate\": \"2016-06-23\",\n        \"PaidDate\": \"2016-07-10\",\n        \"PayForMonth\": \"June 2016\",\n        \"PaymentId\": \"TASKOPAY1001\",\n        \"Status\": \"Completed\",\n        \"VendorId\": \"682D49C154DB16499DA55BF1D50930FF\",\n        \"VendorName\": \"Srikanth\"\n    },\n    {\n        \"__type\": \"Payment:#Tasko.Model\",\n        \"Amount\": 400,\n        \"Description\": \"Partial Payment made\",\n        \"DueDate\": \"2016-06-23\",\n        \"PaidDate\": \"2016-07-10\",\n        \"PayForMonth\": \"June 2016\",\n        \"PaymentId\": \"TASKOPAY1002\",\n        \"Status\": \"Pending\",\n        \"VendorId\": \"682D49C154DB16499DA55BF1D50930FF\",\n        \"VendorName\": \"chandra\"\n    }\n    ],\n    \"Error\": false,\n    \"Message\": \"Success\",\n    \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NO_PAYMENTS_FOUND",
            "description": "<p>No Payments found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"No Payments found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetAllServices",
    "title": "Get All Services",
    "name": "GetAllServices",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n  \"Data\": [\n    {\n     \"__type\": \"ServiceDetail:#Tasko.Model\",\n     \"Service\": {\n       \"Id\": \"5EC9A583EFF0534897DD55B3653627C9\",\n       \"ImageURL\": \"http://api.tasko.in/serviceimages/bikeService.png\",\n       \"Name\": \"Bike Service\",\n       \"ParentServiceId\": null,\n       \"Status\": 0\n     },\n     \"TotalOrders\": 0,\n     \"TotalVendors\": 0\n   },\n   {\n     \"__type\": \"ServiceDetail:#Tasko.Model\",\n     \"Service\": {\n       \"Id\": \"6786E5D449D6B74396E8ADAEA1C17E37\",\n       \"ImageURL\": \"http://api.tasko.in/serviceimages/microwave.png\",\n       \"Name\": \"Microwave Service\",\n       \"ParentServiceId\": null,\n       \"Status\": 0\n     },\n     \"TotalOrders\": 10,\n     \"TotalVendors\": 1\n   },\n   {\n     \"__type\": \"ServiceDetail:#Tasko.Model\",\n     \"Service\": {\n       \"Id\": \"688B6A30A7895D40B3A64A0A03AE28D8\",\n       \"ImageURL\": \"http://api.tasko.in/serviceimages/carpenter.png\",\n       \"Name\": \"Carpentry\",\n       \"ParentServiceId\": null,\n       \"Status\": 0\n     },\n     \"TotalOrders\": 0,\n     \"TotalVendors\": 1\n   }\n     ],\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetAllVendorsSummary",
    "title": "Get All Vendors Summary",
    "name": "GetAllVendorsSummary",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n   \"Data\": [\n    {\n       \"__type\": \"VendorSummary:#Tasko.Model\",\n       \"DueDate\": \"2016-08-13\",\n       \"EmailAddress\": \"mchandu123@gmail.com\",\n       \"IsVendorLive\": true,\n       \"MobileNumber\": \"9985466195\",\n       \"MonthlyCharge\": 300,\n       \"Name\": \"chandra\",\n       \"UniqueId\": 1,\n       \"UserName\": \"chandra\",\n       \"VendorId\": \"365D5778496AF745975DA6692AC64661\"\n    },\n    {\n       \"__type\": \"VendorSummary:#Tasko.Model\",\n       \"DueDate\": \"2016-08-13\",\n       \"EmailAddress\": \"sree@gmail.com\",\n       \"IsVendorLive\": true,\n       \"MobileNumber\": \"1234567890\",\n       \"MonthlyCharge\": 300,\n       \"Name\": \"Srikanth\",\n       \"UniqueId\": 2,\n       \"UserName\": \"srikanth\",\n       \"VendorId\": \"F1EFDAF4136F2847B99F259519C1D729\"\n    }\n    ],\n   \"Error\": false,\n   \"Message\": \"Success\",\n   \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "VENDORS_NOT_FOUND",
            "description": "<p>Vendor's not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Vendor's not found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetAllUsers",
    "title": "Get all the users",
    "name": "GetAllusers",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>user id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Token code got from login API\" ,\n  \"User_Id\": \"User id\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": [\n   {\n     \"__type\": \"User:#Tasko.Model\",\n     \"EmailId\": \"test@test.com\",\n     \"Id\": \"236E155155DB7A489E8101290DEDECE1\",\n     \"IsActive\": true,\n     \"IsAdmin\": true,\n     \"JoinedDate\": \"2016-07-13 20:38:06\",\n     \"MobileNumber\": \"9898987878\",\n     \"Name\": \"testuser\",\n     \"PassWord\": \"testuser\",\n     \"UserName\": null\n   },\n   {\n     \"__type\": \"User:#Tasko.Model\",\n     \"EmailId\": \"testuse1r@testuser.com\",\n     \"Id\": \"EFB93DAEFECC0D409E2AC5FEB4441615\",\n     \"IsActive\": true,\n     \"IsAdmin\": true,\n     \"JoinedDate\": \"2016-07-13 20:32:29\",\n     \"MobileNumber\": \"9898987876\",\n     \"Name\": \"testuser11\",\n     \"PassWord\": \"testuser11\",\n     \"UserName\": null\n   }\n ],\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_CREDENTIALS",
            "description": "<p>Invalid credentials.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n \"Data\": null,\n \"Error\": true,\n \"Message\": \"Invalid token code\",\n \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetCustomerOverview",
    "title": "Get Customer Overview",
    "name": "GetCustomerOverview",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"customerId\":\"6786E5D449D6B74396E8ADAEA1C17E37\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n  \"Data\": {\n    \"__type\": \"CustomerOverview:#Tasko.Model\",\n    \"BiggestPayments\": 600,\n    \"MonthlyPayments\": 3750,\n    \"Name\": \"Shivaji123\",\n    \"TodayOrders\": 0,\n    \"TotalOrders\": 10,\n    \"TotalPayments\": 3750,\n    \"WeeklyOrders\": 10,\n    \"WeeklyPayments\": 3750\n  },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "CUSTOMER_NOT_FOUND",
            "description": "<p>Customer's not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Customer's not found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetDashboardMeters",
    "title": "Get Dashboard Meter Values",
    "name": "GetDashboardMeters",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n    \"Data\": {\n    \"__type\": \"DashboardMeter:#Tasko.Model\",\n    \"TotalCustomerReviews\": 1,\n    \"TotalCustomers\": 3,\n    \"TotalOrders\": 11,\n    \"TotalPayments\": 0,\n    \"TotalServices\": 15,\n    \"TotalUsers\": 0,\n    \"TotalVendorReviews\": 11,\n    \"TotalVendors\": 2\n    },\n    \"Error\": false,\n    \"Message\": \"Success\",\n    \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetDashboardRecentActivities",
    "title": "Get Recent Activities",
    "name": "GetDashboardRecentActivities",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n    \"Data\": [\n    {\n        \"__type\": \"RecentActivities:#Tasko.Model\",\n        \"ActivityId\": \"5FD87BC4BF91424DB08F4298F9580641\",\n        \"ActivityType\": \"ORDER\",\n        \"Comment\": \"TASKO1010 Order  is completed.\",\n        \"CustomerId\": null,\n        \"OrderId\": \"TASKO1010\",\n        \"TimeSince\": \"2016-07-09 17:55:14\",\n        \"VendorId\": null\n    },\n    {\n        \"__type\": \"RecentActivities:#Tasko.Model\",\n        \"ActivityId\": \"08020C7D838046409B42714FEB382761\",\n        \"ActivityType\": \"ORDER\",\n        \"Comment\": \"New Order TASKO1012 has been placed.\",\n        \"CustomerId\": null,\n        \"OrderId\": \"TASKO1012\",\n        \"TimeSince\": \"2016-07-09 17:44:08\",\n        \"VendorId\": null\n    },\n    {\n        \"__type\": \"RecentActivities:#Tasko.Model\",\n        \"ActivityId\": \"272910E262B17D45B16A11F70C5CD3AA\",\n        \"ActivityType\": \"CUSTOMER\",\n        \"Comment\": \"Customer Shaker registered.\",\n        \"CustomerId\": \"13D97F236A0E0547B22A7734B63488F8\",\n        \"OrderId\": null,\n        \"TimeSince\": \"2016-07-09 17:16:29\",\n        \"VendorId\": null\n    },\n    {\n        \"__type\": \"RecentActivities:#Tasko.Model\",\n        \"ActivityId\": \"9D234754C3B4754BBD8B1ECCCB510DCB\",\n        \"ActivityType\": \"VENDOR\",\n        \"Comment\": \"Vendor Chandra registered\",\n        \"CustomerId\": null,\n        \"OrderId\": null,\n        \"TimeSince\": \"2016-07-09 16:59:51\",\n        \"VendorId\": \"13D97F236A0E0547B22A7734B63488F8\"\n    }\n    ],\n    \"Error\": false,\n    \"Message\": \"Success\",\n    \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NO_RECENT_ACTIVITIES",
            "description": "<p>Recent Activities are not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Recent Activities are not found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetDashboardRecentOrdersByStatus",
    "title": "Get Dashboard Recent Orders",
    "name": "GetDashboardRecentOrdersByStatus",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "orderStatusId",
            "description": "<p>Order Status Id {If Order status Id is 6 it will return Completed orders else it will return the pending orders}</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example 1:",
          "content": "{ \n  \"orderStatusId\":6\n}",
          "type": "json"
        },
        {
          "title": "Param-Example 2:",
          "content": "{ \n  \"orderStatusId\":1\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response 1:",
          "content": "{\n \"Data\": [\n   {\n     \"__type\": \"OrderSummary:#Tasko.Model\",\n     \"Comments\": null,\n     \"CustomerName\": \"Shivaji123\",\n     \"OrderId\": \"TASKO1007\",\n     \"OrderStatus\": \"Completed\",\n     \"RequestedDate\": \"2016-07-03 17:43:19\",\n     \"ServiceId\": null,\n     \"ServiceName\": \"Microwave Service\",\n     \"VendorName\": \"Srikanth\"\n   },\n   {\n     \"__type\": \"OrderSummary:#Tasko.Model\",\n     \"Comments\": null,\n     \"CustomerName\": \"Shivaji\",\n     \"OrderId\": \"TASKO1000\",\n     \"OrderStatus\": \"Completed\",\n     \"RequestedDate\": \"2016-07-03 17:43:19\",\n     \"ServiceId\": null,\n     \"ServiceName\": \"Electrician\",\n     \"VendorName\": \"chandra\"\n   }\n ],\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
          "type": "json"
        },
        {
          "title": "Success-Response 2:",
          "content": " {\n  \"Data\": [\n     {\n      \"__type\": \"OrderSummary:#Tasko.Model\",\n      \"Comments\": null,\n      \"CustomerName\": \"Shivaji123\",\n      \"OrderId\": \"TASKO1010\",\n      \"OrderStatus\": \"Requested\",\n      \"RequestedDate\": \"2016-07-03 17:43:19\",\n      \"ServiceId\": null,\n      \"ServiceName\": \"Microwave Service\",\n      \"VendorName\": \"Srikanth\"\n    },\n    {\n      \"__type\": \"OrderSummary:#Tasko.Model\",\n      \"Comments\": null,\n      \"CustomerName\": \"Shivaji123\",\n      \"OrderId\": \"TASKO1009\",\n      \"OrderStatus\": \"Accepted\",\n      \"RequestedDate\": \"2016-07-03 17:43:19\",\n      \"ServiceId\": null,\n      \"ServiceName\": \"Microwave Service\",\n      \"VendorName\": \"Srikanth\"\n    }\n  ],\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "c1/GetOrderDetails",
    "title": "Get Order details",
    "name": "GetOrderDetails",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
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
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"OrderId\": \"Order Id that you would like to get the details\" \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": {\n    \"__type\": \"Order:#Tasko.Model\",\n    \"Comments\": \"\",\n    \"CustomerId\": \"692BD435A5173E42916438F889F5DA08\",\n    \"CustomerName\": \"Shivaji\",\n    \"DestinationAddress\": {\n      \"Address\": \"plot no 404, BaghyaNagar\",\n      \"AddressId\": \"8397A91B6E997F438A9D4D9D49D3E12A\",\n      \"AddressType\":\"Home\",   \n      \"City\": \"Hyderabad\",\n      \"Country\": \"India\",\n      \"Lattitude\": \"40\",\n      \"Locality\": \"HMT HILLS\",\n      \"Longitude\": \"600\",\n      \"Pincode\": \"500072\",\n      \"State\": \"Telangana\"\n    },\n    \"Location\": \"kphb\",\n    \"OrderId\": \"TASKO1000\",\n    \"OrderStatus\": \"Requested\",\n    \"OrderStatusId\": 1,\n    \"RequestedDate\": \"2016-06-29 22:49:47\",\n    \"ServiceId\": \"9661D3C7E345B747BBE62DEA76F00B82\",\n    \"ServiceName\": \"Electrician\",\n    \"SourceAddress\": {\n      \"Address\": \"plot no 101, vivekanandaNagar\",\n      \"AddressId\": \"36F6A0E2C85F7D46AF68C4EB73148B2A\",\n      \"AddressType\":\"Home\",\n      \"City\": \"Hyderabad\",\n      \"Country\": \"India\",\n      \"Lattitude\": \"10\",\n      \"Locality\": \"kphb\",\n      \"Longitude\": \"200\",\n      \"Pincode\": \"500081\",\n      \"State\": \"Telangana\"\n    },\n    \"VendorId\": \"C3A4A364DA1DE542BA70FBAD2435D571\",\n    \"VendorName\": \"chandra\",\n    \"VendorServiceId\": \"CD2CA27D52CE5E4D8E897D53CC4379CB\"\n  },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "ORDER_NOT_FOUND",
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
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetOrders",
    "title": "Get Orders",
    "name": "GetOrders",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "orderStatusId",
            "description": "<p>Order Status Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"orderStatusId\": \"Status of the order\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  {\n    \"Data\": [\n             {\n               \"__type\": \"OrderSummary:#Tasko.Model\",\n               \"Comments\": null,\n               \"CustomerName\": \"Shivaji\",\n               \"OrderId\": \"TASKO1000\",\n               \"OrderStatus\": \"Requested\",\n               \"RequestedDate\": \"2016-07-07 14:12:55\",\n               \"ServiceId\": null,\n               \"ServiceName\": \"Electrician\",\n               \"VendorName\": \"chandra\"\n             },\n             {\n               \"__type\": \"OrderSummary:#Tasko.Model\",\n               \"Comments\": null,\n               \"CustomerName\": \"Shivaji123\",\n               \"OrderId\": \"TASKO1001\",\n               \"OrderStatus\": \"Requested\",\n               \"RequestedDate\": \"2016-07-07 14:12:55\",\n               \"ServiceId\": null,\n               \"ServiceName\": \"Microwave Service\",\n               \"VendorName\": \"srikanth test\"\n             }\n           ]\n   \"Error\": false,\n   \"Message\": \"Success\",\n   \"Status\": 200\n }\n}",
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
            "field": "NO_ORDERS",
            "description": "<p>No orders</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"No orders\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetOrdersByService",
    "title": "Get Orders By Service",
    "name": "GetOrdersByService",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "serviceId",
            "description": "<p>Service Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"serviceId\":\"6786E5D449D6B74396E8ADAEA1C17E37\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": [\n   {\n     \"__type\": \"OrderSummary:#Tasko.Model\",\n     \"Comments\": null,\n     \"CustomerName\": \"Shivaji123\",\n     \"OrderId\": \"TASKO1001\",\n     \"OrderStatus\": \"Requested\",\n     \"RequestedDate\": \"2016-07-03 17:43:19\",\n     \"ServiceId\": \"6786E5D449D6B74396E8ADAEA1C17E37\",\n     \"ServiceName\": \"Microwave Service\",\n     \"VendorName\": \"Srikanth\"\n   },\n   {\n     \"__type\": \"OrderSummary:#Tasko.Model\",\n     \"Comments\": null,\n     \"CustomerName\": \"Shivaji123\",\n     \"OrderId\": \"TASKO1002\",\n     \"OrderStatus\": \"Requested\",\n     \"RequestedDate\": \"2016-07-03 17:43:19\",\n     \"ServiceId\": \"6786E5D449D6B74396E8ADAEA1C17E37\",\n     \"ServiceName\": \"Microwave Service\",\n     \"VendorName\": \"Srikanth\"\n   }\n     ],\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "ORDERS_NOT_FOUND",
            "description": "<p>Order's not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Order's not found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetPayment",
    "title": "Get Payment",
    "name": "GetPayment",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "paymentId",
            "description": "<p>PaymentId.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n    \"paymentId\": \"TASKOPAY1000\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": {\n \"__type\": \"Payment:#Tasko.Model\",\n \"Amount\": 500,\n \"Description\": \"Test\",\n \"DueDate\": \"1986-01-14\",\n \"PaidDate\": \"1999-12-22\",\n \"PayForMonth\": \"May 2016\",\n \"PaymentId\": \"TASKOPAY1000\",\n \"Status\": \"Pending\",\n \"VendorId\": \"682D49C154DB16499DA55BF1D50930FF\",\n \"VendorName\": \"Srikanth\"\n },\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NO_PAYMENT_FOUND",
            "description": "<p>No Payments found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"No Paymnet found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetPaymentInvoice",
    "title": "Get Payment Invoice",
    "name": "GetPaymentInvoice",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "paymentId",
            "description": "<p>PaymentId.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n    \"paymentId\": \"TASKOPAY1000\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n  \"Data\": {\n    \"__type\": \"VendorPaymentInvoice:#Tasko.Model\",\n    \"Payment\": {\n      \"Amount\": 500,\n      \"Description\": \"Test\",\n      \"DueDate\": \"1986-01-14\",\n      \"PaidDate\": \"1999-12-22\",\n      \"PayForMonth\": \"May 2016\",\n      \"PaymentId\": \"TASKOPAY1000\",\n      \"Status\": \"Pending\",\n      \"VendorId\": \"682D49C154DB16499DA55BF1D50930FF\",\n      \"VendorName\": \"Srikanth\"\n    },\n    \"VendorAddress\": {\n      \"Address\": \"plot no 404, BaghyaNagar\",\n      \"AddressId\": \"F3378ADDB47E164DB5A585CCC36FC5BA\",\n      \"AddressType\":\"Home\",\n      \"City\": \"Hyderabad\",\n      \"Country\": \"India\",\n      \"Lattitude\": \"40\",\n      \"Locality\": \"HMT HILLS\",\n      \"Longitude\": \"600\",\n      \"Pincode\": \"500072\",\n      \"State\": \"Telangana\"\n    }\n  },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NO_PAYMENT_FOUND",
            "description": "<p>No Payments found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"No Paymnet found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetServiceOverview",
    "title": "Get Service Overview",
    "name": "GetServiceOverview",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "serviceId",
            "description": "<p>Service Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"serviceId\":\"6786E5D449D6B74396E8ADAEA1C17E37\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n  \"Data\": {\n    \"__type\": \"ServiceOverview:#Tasko.Model\",\n    \"BiggestPayment\": 600,\n    \"MonthlyPayments\": 3750,\n    \"ServiceId\": \"43FFEE168D9E3C4B9FC28B263AA403F7\",\n    \"ServiceName\": \"Microwave Service\",\n    \"TotalPayments\": 3750,\n    \"WeeklyPayments\": 3750\n  },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NO_SERVICES_EXIST",
            "description": "<p>No Payments found for the selected service.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"No Payments found for the selected service\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetServicesForVendor",
    "title": "Get Services For Vendor",
    "name": "GetServicesForVendor",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"vendorId\":\"AFB2B50F2164804C8E6D26A6C4A32982\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n  \"Data\": [\n           {\n             \"__type\": \"ServicesForVendor:#Tasko.Model\",\n             \"IsActive\": false,\n             \"ServiceId\": \"F4878463A2FF5043BF3763F8AA913DE1\",\n             \"ServiceName\": \"Microwave Service\"\n           }\n         ],\n         \"Error\": false,\n         \"Message\": \"Success\",\n         \"Status\": 200\n}",
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
            "field": "SERVICES_NOT_FOUND",
            "description": "<p>Services not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Services not found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetVendorOverview",
    "title": "Get Vendor overview",
    "name": "GetVendorOverview",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>VendorId</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"vendorId\": \"AFB2B50F2164804C8E6D26A6C4A32982\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n   \"Data\": {\n               \"__type\": \"VendorOverview:#Tasko.Model\",\n               \"AverageMonthlyAmount\": 3750,\n               \"HighestOrderAmount\": 600,\n               \"Name\": \"Srikanth\",\n               \"OrdersThisWeek\": 10,\n               \"OrdersToday\": 10,\n               \"TotalOrderAmount\": 3750,\n               \"TotalOrders\": 10,\n               \"WeeklyOrderAmount\": 3750\n             },\n   \"Error\": false,\n   \"Message\": \"Success\",\n   \"Status\": 200\n}",
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
            "field": "VENDOR_NOT_FOUND",
            "description": "<p>Vendor not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Vendor not found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetVendorsByService",
    "title": "Get Vendors By Service",
    "name": "GetVendorsByService",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "serviceId",
            "description": "<p>Service Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"serviceId\":\"6786E5D449D6B74396E8ADAEA1C17E37\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n    \"Data\": [\n    {\n        \"__type\": \"VendorSummary:#Tasko.Model\",\n        \"EmailAddress\": \"sree@gmail.com\",\n        \"VendorId\": \"6D76BCF5246BB44E8DD327C22780C6B0\",\n        \"IsVendorLive\": true,\n        \"MobileNumber\": \"1234567890\",\n        \"Name\": \"Srikanth\",\n        \"UserName\": \"sree123\"\n    }\n    ],\n    \"Error\": false,\n    \"Message\": \"Success\",\n    \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "VENDORS_NOT_FOUND",
            "description": "<p>Vendor's not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Vendor's not found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/GetVendorsByStatus",
    "title": "Get Vendors by Status",
    "name": "GetVendorsByStatus",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorStatus",
            "description": "<p>Vendor Status {0- All, 1-Online, 2-Offline   }</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"vendorStatus\": \"0\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n   \"Data\": [\n               {\n                 \"__type\": \"VendorSummary:#Tasko.Model\",\n                 \"EmailAddress\": \"mchandu123@gmail.com\",\n                 \"VendorId\": \"40C58B1908D4CE439FA05FF0B138EA8A\",\n                 \"IsVendorLive\": true,\n                 \"MobileNumber\": \"9985466195\",\n                 \"Name\": \"chandra\",\n                 \"UserName\": \"chandra\"\n               },\n               {\n                 \"__type\": \"VendorSummary:#Tasko.Model\",\n                 \"EmailAddress\": \"sree@gmail.com\",\n                 \"VendorId\": \"B6C163EABE8C0A4B8F4BAFA9CAA7DDB1\",\n                 \"IsVendorLive\": true,\n                 \"MobileNumber\": \"1234567890\",\n                 \"Name\": \"Srikanth\",\n                 \"UserName\": \"srikanth\"\n               }\n         ],\n   \"Error\": false,\n   \"Message\": \"Success\",\n   \"Status\": 200\n}",
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
            "field": "NO_VENDORS",
            "description": "<p>Vendors not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Vendors not found\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/Login",
    "title": "Login",
    "name": "Login",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Auth_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Auth_Code\": \"Authetication code that is generated using GetAuthCode API\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "userName",
            "description": "<p>user name of customer.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "password",
            "description": "<p>password.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"userName\": \"kranthi \",\n  \"password\":\"kranthi\"\n  }",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": {\n   \"__type\": \"LoginInfo:#Tasko.Model\",\n   \"TokenId\": \"B282108B71974748876F5BAC53A93F\",\n   \"UserId\": \"E51DF58EF04A1947BE85BB5B04AC94A9\"\n },\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_CREDENTIALS",
            "description": "<p>Invalid credentials.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": {\n    \"__type\": \"LoginInfo:#Tasko.Model\",\n    \"TokenId\": \"7BC33345FA08BF488335AC75E3DBA6\",\n    \"UserId\": null\n  },\n  \"Error\": false,\n  \"Message\": \"Invalid Credentials\",\n  \"Status\": 200\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/UpdatePayment",
    "title": "Update Payment",
    "name": "UpdatePayment",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Payment",
            "optional": false,
            "field": "payment",
            "description": "<p>Payment details.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n    \"payment\": {\n    \"PaymentId\": \"TASKOPAY1002\"\n    \"VendorId\": \"F9756A47F455F64DAD4B24E49A257188\",\n    \"DueDate\": \"23/6/2016\",\n    \"PaidDate\": \"10/7/2016\",\n    \"Amount\": 400,\n    \"Status\": \"Completed\",\n    \"Description\": \"OutStanding Charge\",\n    \"PayForMonth\": \"June 2016\"\n    }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/UpdateService",
    "title": "Update Service",
    "name": "UpdateService",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Service",
            "optional": false,
            "field": "service",
            "description": "<p>Service Info.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"service\":\n  {   \n    \"Id\":\"054CFD4A388C27046918399822EAA7458\",\n    \"Name\": \"AC Service\",\n    \"ParentServiceId\": \"\",\n    \"ImageUrl\": \"http://api.tasko.in/serviceimages/ac_services.png\",\n    \"Status\": \"1\"\n  }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/UpdateServicesForVendor",
    "title": "Update Services For Vendor",
    "name": "UpdateServicesForVendor",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>VendorId</p>"
          },
          {
            "group": "Parameter",
            "type": "ServicesForVendor",
            "optional": false,
            "field": "services",
            "description": "<p>List of services for vendor.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{ \n  \"vendorId\": \"AFB2B50F2164804C8E6D26A6C4A32982\",\n  \"Data\": [\n                    {\n                      \"ServiceId\": \"F4878463A2FF5043BF3763F8AA913DE1\",\n                    }\n                  ]\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n  \"Data\": null,\n   \"Error\": false,\n   \"Message\": \"Success\",\n   \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n   \"Data\": null,\n   \"Error\": true,\n   \"Message\": \"Invalid token code\",\n   \"Status\": 400\n }",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/UpdateUserStatus",
    "title": "Updates user status",
    "name": "UpdateUserStatus",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>user id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Token code got from login API\" ,\n  \"User_Id\": \"User id\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "userId",
            "description": "<p>user id of admin user.</p>"
          },
          {
            "group": "Parameter",
            "type": "Bool",
            "optional": false,
            "field": "isActive",
            "description": "<p>whether user is active</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "\n{\n  \"userId\":\"EFB93DAEFECC0D409E2AC5FEB4441615\",\n  \"isActive\":false\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": null,\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "FAIL",
            "description": "<p>updating status failed</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Fail\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "v1/UpdateVendorDetails",
    "title": "Update Vendor Details",
    "name": "UpdateVendorDetails",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Vendor",
            "optional": false,
            "field": "vendor",
            "description": "<p>Vendor.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendor\": {\n             \"Id\": \"FC73EC7242E28142ACCAFDF4703F0EBF\",\n             \"MobileNumber\": \"9849345086\",\n             \"Name\": \"srikanth\",\n             \"EmailAddress\":\"srikanth@tasko.com\",\n             \"Photo\": \"\",\n             \"DateOfBirth\":\"2016-07-07 14:12:55\",\n             \"AreOrdersBlocked\":\"0\",\n             \"IsBlocked\":\"0\",\n             \"IsPowerSeller\":\"1\",\n             \"MonthlyCharge\":\"300\",\n             \n            } \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "a1/auth",
    "title": "Get Auth Code",
    "name": "auth",
    "group": "Admin",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "X-APIKey",
            "description": "<p>API key</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"X-APIKey\": \"API Key\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": \"API key comes here\",\n  \"Error\": false,\n  \"Message\": \"Authentication Successful\",\n  \"Status\": 200\n}",
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
            "field": "Authentication",
            "description": "<p>failed.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Authentication failed\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IAdminService.cs",
    "groupTitle": "Admin"
  },
  {
    "type": "post",
    "url": "c1/AddComplaint",
    "title": "Add Complaint",
    "name": "AddComplaint",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "complaint",
            "description": "<p>complaint.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n                \"complaint\":\n                  {\n                  \"__type\": \"Complaint:#Tasko.Model\",\n                  \"OrderId\": \"TASKO1000\",\n                  \"Title\": \"Test\",\n                  \"ComplaintChats\": [\n                                      {\n                                        \"__type\": \"ComplaintChat:#Tasko.Model\",\n                                        \"ChatContent\": \"testing\"\n                                      }\n                                  ]\n                 }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": \"Complaint#1001\",\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "ERROR_ADDING_COMPLAINT",
            "description": "<p>Error Adding Complaint.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Error Adding Complaint\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/AddComplaintChat",
    "title": "Add Complaint Chat",
    "name": "AddComplaintChat",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "complaint",
            "description": "<p>complaint.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n      \"complaintChat\":\n                      {\n                      \"__type\": \"ComplaintChat:#Tasko.Model\",\n                      \"ComplaintId\": \"Complaint#1004\",\n                      \"ChatContent\": \"test data\"\n                     }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid Token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid Token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/AddCustomerAddress",
    "title": "Add Customer Address",
    "name": "AddCustomerAddress",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "AddressInfo",
            "optional": false,
            "field": "addressInfo",
            "description": "<p>Address Info.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n \"customerId\": \"10E4394670195C4AA1E4B7130A514187 \",\n \"addressInfo\": \n   {\n    \"Address\": \"plot no 101, vivekanandaNagar\",\n    \"AddressType\":\"Home\",\n    \"City\": \"Hyderabad\",\n    \"Country\": \"India\",\n    \"Lattitude\": \"10\",\n    \"Locality\": \"kphb\",\n    \"Longitude\": \"200\",\n    \"Pincode\": \"500081\",\n    \"State\": \"Telangana\"\n   }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "CUSTOMER_DETAILS_INVALID",
            "description": "<p>Customer Id and address are mandatory.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Customer Id and address are mandatory\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/AddVendorRating",
    "title": "Add Vendor Rating",
    "name": "AddVendorRating",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "orderId",
            "description": "<p>Order Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "VendorRating",
            "optional": false,
            "field": "vendorRating",
            "description": "<p>Vendor Rating.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"orderId\":\"TASKO1012\",\n  \"vendorRating\":\n  {   \n    \"CustomerId\": \"10E4394670195C4AA1E4B7130A514187\",\n    \"VendorId\": \"B0269B0769CC8D48AEB92D2513EA14D6\",\n    \"ServiceQuality\": \"5\",\n    \"Punctuality\": \"5\",\n    \"Courtesy\": \"5\",\n    \"Price\": \"5\",\n    \"Comments\":\"Excellent\"\n  }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/ConfirmOrder",
    "title": "Confirm Order",
    "name": "ConfirmOrder",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Order",
            "optional": false,
            "field": "order",
            "description": "<p>order.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": " {\n   \"order\": {\n   \"Comments\": \"\",\n   \"CustomerId\": \"10E4394670195C4AA1E4B7130A514187\",\n   \"CustomerName\": \"srikanth test\",\n   \"CustomerPhone\": \"9999999999\",\n   \"DestinationAddress\": {\n     \"Address\": \"plot no 404, BaghyaNagar\",\n     \"AddressType\":\"Home\",\n     \"City\": \"Hyderabad\",\n     \"Country\": \"India\",\n     \"Lattitude\": \"40\",\n     \"Locality\": \"HMT HILLS\",\n     \"Longitude\": \"600\",\n     \"Pincode\": \"500072\",\n     \"State\": \"Telangana\"\n   },\n   \"Location\": \"kphb\",\n   \"OrderStatus\": \"Requested\",\n   \"OrderStatusId\": 1,\n   \"RequestedDate\": \"/Date(1465353306423+0530)/\",\n   \"ServiceId\": \"BF0860B092FA2447AE6AA8B3609FDCA9\",\n   \"ServiceName\": \"Microwave Service\",\n   \"SourceAddress\": {\n     \"Address\": \"plot no 101, vivekanandaNagar\",\n     \"AddressType\":\"Home\",\n     \"City\": \"Hyderabad\",\n     \"Country\": \"India\",\n     \"Lattitude\": \"10\",\n     \"Locality\": \"kphb\",\n     \"Longitude\": \"200\",\n     \"Pincode\": \"500081\",\n     \"State\": \"Telangana\"\n   },\n   \"VendorId\": \"B0269B0769CC8D48AEB92D2513EA14D6\",\n   \"VendorName\": \"Srikanth\",\n   \"VendorServiceId\": \"C9C834D79EE3BC48BF8D5669B2560D24\"\n }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": \"OrderId: TASKO1012\",\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "ORDER_NOT_CONFIRMED",
            "description": "<p>Order not Confirmed.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Order not Confirmed\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/DeleteCustomerAddress",
    "title": "Delete Customer Address",
    "name": "DeleteCustomerAddress",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "addressId",
            "description": "<p>Address Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n \"customerId\": \"10E4394670195C4AA1E4B7130A514187\",\n \"addressId\": \"346E84F8827D624FB39829A35A23209B\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_DETAILS",
            "description": "<p>Invalid Details.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid Details\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/DeleteFavoriteVendor",
    "title": "Delete Favorite Vendor",
    "name": "DeleteFavoriteVendor",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"customerId\": \"customer Id that you would like to remove association for the given vendor Id\" \n  \"vendorId\": \"Vendor Id that you would like to remove from favorite list\" \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_DETAILS",
            "description": "<p>Invalid Details.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid Details\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "v1/GenerateOTP",
    "title": "Generate OTP",
    "name": "GenerateOTP",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Auth_Code",
            "description": "<p>Authentication Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Auth_Code\": \"Authentication code generated using Auth API\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "emailId",
            "description": "<p>Email Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "phoneNumber",
            "description": "<p>Phone number.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n \"emailId\": \"\",\n \"phoneNumber\": \"9849345086\",\n \"checkUserExistence\": true\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": null,\n \"Error\": false,\n \"Message\": \"Successs\",\n \"Status\": 200\n}",
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
            "field": "ERROR_GENERATING_OTP",
            "description": "<p>Error Generating OTP.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Error Generating OTP\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/GetCustomerAddresses",
    "title": "Get Customer Address",
    "name": "GetCustomerAddresses",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n \"customerId\": \"10E4394670195C4AA1E4B7130A514187 \",\n\"addressInfo\": \n {\n    \"Address\": \"plot no 101, vivekanandaNagar\",\n    \"AddressId\": \"542875B7E7719942AA82B3EABCEE64BF\",\n    \"AddressType\":\"Home\",\n    \"City\": \"Hyderabad\",\n    \"Country\": \"India\",\n    \"Lattitude\": \"10\",\n    \"Locality\": \"kphb\",\n    \"Longitude\": \"200\",\n    \"Pincode\": \"500081\",\n    \"State\": \"Telangana\"\n  }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"AddressInfo:#Tasko.Model\",\n              \"Address\": \"plot no 101, vivekanandaNagar\",\n              \"AddressId\": \"B7DD393239CE854FA5596C67DBF12DD0\",\n              \"AddressType\":\"Home\",\n              \"City\": \"Hyderabad\",\n              \"Country\": \"India\",\n              \"Lattitude\": \"10\",\n              \"Locality\": \"kphb\",\n              \"Longitude\": \"200\",\n              \"Pincode\": \"500081\",\n              \"State\": \"Telangana\"\n            },\n            {\n              \"__type\": \"AddressInfo:#Tasko.Model\",\n              \"Address\": \"plot no 101, vivekanandaNagar\",\n              \"AddressId\": \"4CDE7B6962CFEC4FB9722081E75DC21C\",\n              \"AddressType\":\"Home\",\n              \"City\": \"Hyderabad\",\n              \"Country\": \"India\",\n              \"Lattitude\": \"10\",\n              \"Locality\": \"kphb\",\n              \"Longitude\": \"200\",\n              \"Pincode\": \"500081\",\n              \"State\": \"Telangana\"\n            },\n            {\n              \"__type\": \"AddressInfo:#Tasko.Model\",\n              \"Address\": \"plot no 101, vivekanandaNagar\",\n              \"AddressId\": \"BD0E478182ED4C4FB12CE7CD580C910A\",\n              \"AddressType\":\"Home\",\n              \"City\": \"Hyderabad\",\n              \"Country\": \"India\",\n              \"Lattitude\": \"10\",\n              \"Locality\": \"kphb\",\n              \"Longitude\": \"200\",\n              \"Pincode\": \"500081\",\n              \"State\": \"Telangana\"\n            }\n          ],\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "CUSTOMER_ADDRESS_NOT_FOUND",
            "description": "<p>Customer Addresses not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Customer Addresses not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/GetCustomerComplaints",
    "title": "Get Customer Complaints",
    "name": "GetCustomerComplaints",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>customer Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n      {\n                  \"customerId\": \"D519EDD9B0713B4699E75C0D24F54370\"\n                }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"Complaint:#Tasko.Model\",\n              \"ComplaintChats\": null,\n              \"ComplaintId\": \"Complaint#1000\",\n              \"ComplaintStatus\": 0,\n              \"DueDate\": null,\n              \"LoggedDate\": \"2016-07-16 07:16:28\",\n              \"OrderId\": null,\n              \"Title\": \"Test\"\n            }\n          ],\n          \"Error\": false,\n          \"Message\": \"Success\",\n          \"Status\": 200\n}",
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
            "field": "COMPLAINT_NOT_FOUND",
            "description": "<p>Complaints not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Complaints not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/GetCustomerDetails",
    "title": "Get Customer Details",
    "name": "GetCustomerDetails",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"customerId\": \"Customer id\" \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": {\n            \"__type\": \"Customer:#Tasko.Model\",\n            \"EmailAddress\": \"srikanth.penmetsa@gmail.com\",\n            \"Id\": \"F501CE6E98E3A549B024E1565561EC62\",\n            \"MobileNumber\": \"9849345086\",\n            \"Name\": \"srikanth test\"\n          },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "CUSTOMER_NOT_FOUND",
            "description": "<p>Customer not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Customer not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/GetCustomerOrders",
    "title": "Get Customer Orders",
    "name": "GetCustomerOrders",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "orderStatus",
            "description": "<p>Order Status.</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "pageNumber",
            "description": "<p>Page Number.</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "recordsPerPage",
            "description": "<p>Records Per Page.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n \"customerId\":\"10E4394670195C4AA1E4B7130A514187\",\n \"orderStatus\":\"1\",\n \"pageNumber\":\"\",\n \"recordsPerPage\":\"\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"OrderSummary:#Tasko.Model\",\n              \"Comments\": \"\",\n              \"OrderId\": \"TASKO1011\",\n              \"OrderStatus\": \"Requested\",\n              \"RequestedDate\": \"2016-06-08 07:33:17\",\n              \"ServiceId\": \"0AEAC4261E569C498A05ABBEEC84EA55\",\n              \"ServiceName\": \"Microwave Service\"\n            },\n            {\n              \"__type\": \"OrderSummary:#Tasko.Model\",\n              \"Comments\": \"\",\n              \"OrderId\": \"TASKO1012\",\n              \"OrderStatus\": \"Requested\",\n              \"RequestedDate\": \"2016-07-01 18:17:44\",\n              \"ServiceId\": \"0AEAC4261E569C498A05ABBEEC84EA55\",\n              \"ServiceName\": \"Microwave Service\"\n            }\n          ],\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "ORDERS_NOT_FOUND",
            "description": "<p>Orders not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Orders not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/GetFavoriteVendors",
    "title": "Get Favorite Vendors",
    "name": "GetFavoriteVendors",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"customerId\": \"BA09714B34AEEC4BB84A5675FB3662BD\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"FavoriteVendor:#Tasko.Model\",\n              \"OverallRating\": 3,\n              \"TotalRatings\": 11,\n              \"VendorId\": \"FC73EC7242E28142ACCAFDF4703F0EBF\",\n              \"VendorName\": \"srikanth\"\n            }\n          ],\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/GetNearbyVendors",
    "title": "Get Nearby Vendors",
    "name": "GetNearbyVendors",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "longitude",
            "description": "<p>Longitude of Vendor.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "latitude",
            "description": "<p>Latitude of Vendor.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n   \"latitude\": \"17.3850440\",\n             \"longitude\": \"78.4866710\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "        {\n \"Data\": [\n           {\n             \"__type\": \"VendorSummary:#Tasko.Model\",\n             \"Distance\": 4,\n             \"DueDate\": null,\n             \"EmailAddress\": null,\n             \"IsVendorLive\": false,\n             \"Latitude\": 17.385,\n             \"Longitude\": 78.4867,\n             \"MobileNumber\": null,\n             \"MonthlyCharge\": 0,\n             \"Name\": \"Srikanth\",\n             \"UniqueId\": 0,\n             \"UserName\": \"srikanth\",\n             \"VendorId\": \"F3E6D9CBF8EF6A4289E1FC3509076D54\"\n           }\n         ],\n \"Error\": false,\n\"Message\": \"Success\",\n\"Status\": 200\n       }",
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
            "field": "NO_NEARBY_VENDORS",
            "description": "<p>No Nearby Vendors</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"No Nearby Vendors\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/GetOrderDetails",
    "title": "Get Order details",
    "name": "GetOrderDetails",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
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
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"OrderId\": \"Order Id that you would like to get the details\" \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": {\n    \"__type\": \"Order:#Tasko.Model\",\n    \"Comments\": \"\",\n    \"CustomerId\": \"692BD435A5173E42916438F889F5DA08\",\n    \"CustomerName\": \"Shivaji\",\n    \"DestinationAddress\": {\n      \"Address\": \"plot no 404, BaghyaNagar\",\n      \"AddressId\": \"8397A91B6E997F438A9D4D9D49D3E12A\",\n      \"AddressType\":\"Home\",\n      \"City\": \"Hyderabad\",              \n      \"Country\": \"India\",\n      \"Lattitude\": \"40\",\n      \"Locality\": \"HMT HILLS\",\n      \"Longitude\": \"600\",\n      \"Pincode\": \"500072\",\n      \"State\": \"Telangana\"\n    },\n    \"Location\": \"kphb\",\n    \"OrderId\": \"TASKO1000\",\n    \"OrderStatus\": \"Requested\",\n    \"OrderStatusId\": 1,\n    \"RequestedDate\": \"2016-06-29 22:49:47\",\n    \"ServiceId\": \"9661D3C7E345B747BBE62DEA76F00B82\",\n    \"ServiceName\": \"Electrician\",\n    \"SourceAddress\": {\n      \"Address\": \"plot no 101, vivekanandaNagar\",\n      \"AddressId\": \"36F6A0E2C85F7D46AF68C4EB73148B2A\",\n      \"AddressType\":\"Home\",\n      \"City\": \"Hyderabad\",\n      \"Country\": \"India\",\n      \"Lattitude\": \"10\",\n      \"Locality\": \"kphb\",\n      \"Longitude\": \"200\",\n      \"Pincode\": \"500081\",\n      \"State\": \"Telangana\"\n    },\n    \"VendorId\": \"C3A4A364DA1DE542BA70FBAD2435D571\",\n    \"VendorName\": \"chandra\",\n    \"VendorServiceId\": \"CD2CA27D52CE5E4D8E897D53CC4379CB\"\n  },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "ORDER_NOT_FOUND",
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
    "type": "post",
    "url": "c1/GetRecentOrder",
    "title": "Get Recent Order",
    "name": "GetRecentOrder",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n \"customerId\": \"F501CE6E98E3A549B024E1565561EC62\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": {\n            \"__type\": \"Order:#Tasko.Model\",\n            \"Comments\": \"\",\n            \"CustomerId\": \"F501CE6E98E3A549B024E1565561EC62\",\n            \"CustomerName\": \"srikanth test\",\n            \"DestinationAddress\": {\n              \"Address\": \"plot no 404, BaghyaNagar\",\n              \"AddressId\": \"3E71FF52AF41AC448F11C6085D4BDC69\",\n              \"AddressType\":\"Home\",\n              \"City\": \"Hyderabad\",\n              \"Country\": \"India\",\n              \"Lattitude\": \"40\",\n              \"Locality\": \"HMT HILLS\",\n              \"Longitude\": \"600\",\n              \"Pincode\": \"500072\",\n              \"State\": \"Telangana\"\n            },\n            \"Location\": \"\",\n            \"OrderId\": \"TASKO1011\",\n            \"OrderStatus\": \"Requested\",\n            \"OrderStatusId\": 1,\n            \"RequestedDate\": \"2016-06-08 07:33:17\",\n            \"ServiceId\": \"0AEAC4261E569C498A05ABBEEC84EA55\",\n            \"ServiceName\": \"Microwave Service\",\n            \"SourceAddress\": {\n              \"Address\": \"plot no 101, vivekanandaNagar\",\n              \"AddressId\": \"97B42A2664F905489E9B2E4524EDB0E2\",\n              \"AddressType\":\"Home\",\n              \"City\": \"Hyderabad\",\n              \"Country\": \"India\",\n              \"Lattitude\": \"10\",\n              \"Locality\": \"kphb\",\n              \"Longitude\": \"200\",\n              \"Pincode\": \"500081\",\n              \"State\": \"Telangana\"\n            },\n            \"VendorId\": \"FC73EC7242E28142ACCAFDF4703F0EBF\",\n            \"VendorName\": \"srikanth\",\n            \"VendorServiceId\": \"CF9A27B3DA0D5E418B1A8E6CC79218AD\"\n          },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "ORDER_NOT_FOUND",
            "description": "<p>The Order not found.</p>"
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
    "type": "post",
    "url": "c1/GetServiceVendors",
    "title": "Get Service Vendors",
    "name": "GetServiceVendors",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "serviceId",
            "description": "<p>Service Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "latitude",
            "description": "<p>Latitude.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "longitude",
            "description": "<p>Longitude.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"serviceId\": \"47DAF7A1B95E8040BD9FA90252E72E17\",\n  \"customerId\": \"10E4394670195C4AA1E4B7130A514187\",\n  \"latitude\": \"17.3850440\",\n  \"longitude\": \"78.4866710\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"ServiceVendor:#Tasko.Model\",\n              \"BaseRate\": 82,\n              \"IsFavoriteVendor\": true,\n              \"OverAllRating\": 3,\n              \"ServiceId\": \"0AEAC4261E569C498A05ABBEEC84EA55\",\n              \"ServiceName\": \"Microwave Service\",\n              \"TotalReviews\": 10,\n              \"VendorId\": \"FC73EC7242E28142ACCAFDF4703F0EBF\",\n              \"VendorName\": \"srikanth\",\n              \"VendorServiceId\": \"CF9A27B3DA0D5E418B1A8E6CC79218AD\",\n              \"Distance\": 4\n            }\n          ],\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "VENDORS_NOT_FOUND",
            "description": "<p>Vendors are not found for the selected service.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Vendors are not found for the selected service\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/GetServices",
    "title": "Get Services",
    "name": "GetServices",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "optional": false,
            "field": "\\n.",
            "description": ""
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": [\n           {\n             \"__type\": \"Service:#Tasko.Model\",\n             \"Id\": \"0230AB8F8DB92548A58BC7F3FCD6C310\",\n             \"ImageURL\": \"\",\n             \"Name\": \"Refrigerator Service\",\n             \"ParentServiceId\": null\n           },\n           {\n             \"__type\": \"Service:#Tasko.Model\",\n             \"Id\": \"098DF6729F546143B0D9FC824227D384\",\n             \"ImageURL\": \"http://api.tasko.in/serviceimages/ac_services.png\",\n             \"Name\": \"AC Service\",\n             \"ParentServiceId\": null\n           },\n           {\n             \"__type\": \"Service:#Tasko.Model\",\n             \"Id\": \"0AEAC4261E569C498A05ABBEEC84EA55\",\n             \"ImageURL\": \"\",\n             \"Name\": \"Microwave Service\",\n             \"ParentServiceId\": null\n           }\n         ]\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "SERVICES_NOT_FOUND",
            "description": "<p>Services not found.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Services not found\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "v1/Login",
    "title": "Login",
    "name": "Login",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Auth_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Auth_Code\": \"Authetication code that is generated using GetAuthCode API\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "name",
            "description": "<p>name of customer.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "OTP",
            "description": "<p>OTP.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"phoneNumber\": \"9849345086\",\n  \"OTP\": \"8FTLYc\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": {\n           \"__type\": \"LoginInfo:#Tasko.Model\",\n           \"TokenId\": \"5E1A3D0D493A754D820AECB8AC40E790\",\n           \"UserId\": \"F501CE6E98E3A549B024E1565561EC62\"\n         },\n \"Error\": false,\n \"Message\": \"Successs\",\n \"Status\": 200\n}",
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
            "field": "INVALID_OTP_PHONENUMBER",
            "description": "<p>Invalid Phone Number Or OTP.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid Phone Number Or OTP\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/SaveOfflineVendorRequest",
    "title": "Save Offline Vendor Request",
    "name": "SaveOfflineVendorRequest",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "serviceId",
            "description": "<p>Service Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "area",
            "description": "<p>area.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"customerId\": \"customer Id that you would like to remove association for the given vendor Id\" \n  \"serviceId\": \"Service Id that the customer wants\" \n  \"area\": \"Area where the customer wants service for\" \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/SetFavoriteVendor",
    "title": "Set Favorite Vendor",
    "name": "SetFavoriteVendor",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n \"customerId\": \"BA09714B34AEEC4BB84A5675FB3662BD\",\n \"vendorId\": \"ACC75F79F2CFD94E8434D2B3E848889E\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "v1/SignUp",
    "title": "SignUp",
    "name": "SignUp",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Auth_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Auth_Code\": \"Authetication code that is generated using GetAuthCode API\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "name",
            "description": "<p>name of customer.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "emailId",
            "description": "<p>Email.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "phoneNumber",
            "description": "<p>Phone number.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"name\": \"srikanth test\",\n  \"emailId\": \"srikanth.penmetsa@gmail.com\",\n  \"phoneNumber\": \"9849345086\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": {\n           \"__type\": \"LoginInfo:#Tasko.Model\",\n           \"TokenId\": \"5064D3286F70DB4D955D74BD81D58C1F\",\n           \"UserId\": \"401C251B97FC624CB35D94088F1378DA\"\n         },\n \"Error\": false,\n \"Message\": \"Successs\",\n \"Status\": 200\n}",
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
            "field": "INVALID_AUTHCODE",
            "description": "<p>Invalid Authcode.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid Authcode\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/StoreCustomerGCMUser",
    "title": "Store Vendor GCM User",
    "name": "StoreCustomerGCMUser",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "customerId",
            "description": "<p>Customer Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "name",
            "description": "<p>GCM User Name .</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "gcmRedId",
            "description": "<p>GCMREDID.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"customerId\":\"Customer Id\",\n            \"name\": \"srikanth\",\n            \"gcmRedId\": \"gcm reg Id\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": \"0C12E1E9EF74CD499EAAEDB8FFDCE74A\",\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "USER_NAME_EXISTS",
            "description": "<p>User Name Exists</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"User Name Exists\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/UpdateCustomer",
    "title": "Update Customer",
    "name": "UpdateCustomer",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Customer",
            "optional": false,
            "field": "Customer",
            "description": "<p>Customer.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n\"customer\":\n {\n  \"Id\": \"10E4394670195C4AA1E4B7130A514187\",\n  \"Name\": \"srikanth testing\",\n  \"EmailAddress\": \"penmetsa.srikanth@gmail.com\",\n  \"MobileNumber\": \"9849345086\"\n }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/UpdateCustomerAddress",
    "title": "Update Customer Address",
    "name": "UpdateCustomerAddress",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "AddressInfo",
            "optional": false,
            "field": "addressInfo",
            "description": "<p>Address Info.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n   \"addressInfo\": \n     {\n       \"Address\": \"plot no 101, vivekanandaNagar\",\n       \"AddressId\": \"542875B7E7719942AA82B3EABCEE64BF\",\n       \"AddressType\":\"Home\",\n       \"City\": \"Hyderabad\",\n       \"Country\": \"India\",\n       \"Lattitude\": \"10\",\n       \"Locality\": \"kphb\",\n       \"Longitude\": \"200\",\n       \"Pincode\": \"500081\",\n       \"State\": \"Telangana\"\n     }\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "CUSTOMER_ADDRESS_INVALID",
            "description": "<p>Customer Address Invalid.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Customer Address Invalid\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "v1/ValidateOTP",
    "title": "Validate OTP",
    "name": "ValidateOTP",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Auth_Code",
            "description": "<p>Authntication code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Auth_Code\": \"Authetication code that is generated using GetAuthCode API\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "phoneNumber",
            "description": "<p>Phone number.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "OTP",
            "description": "<p>OTP to login.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n \"phoneNumber\": \"9849345086\",\n \"OTP\": \"E3rwSC\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": null,\n \"Error\": false,\n \"Message\": \"Successs\",\n \"Status\": 200\n}",
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
            "field": "INVALID_OTP",
            "description": "<p>Invalid OTP.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid OTP\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/ICustomerService.cs",
    "groupTitle": "Customer"
  },
  {
    "type": "post",
    "url": "c1/auth",
    "title": "Get Auth Code",
    "name": "auth",
    "group": "Customer",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "X-APIKey",
            "description": "<p>API key</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"X-APIKey\": \"API Key\" ,\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": \"API key comes here\",\n  \"Error\": false,\n  \"Message\": \"Authentication Successful\",\n  \"Status\": 200\n}",
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
            "field": "Authentication",
            "description": "<p>failed.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Authentication failed\",\n  \"Status\": 400\n}",
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
    "url": "v1/ChangePassword",
    "title": "Change password",
    "name": "ChangePassword",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "password",
            "description": "<p>Password.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "oldPassword",
            "description": "<p>Old Password.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorId\": \"Vendor Id\",\n  \"password\": \"New Password\",\n  \"oldPassword\": \"Old Password\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": null,\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "INVALID_OLD_PASSWORD",
            "description": "<p>Invalid old password</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid old password\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/GetVendorDetails",
    "title": "Get Vendor details",
    "name": "GetVendorDetails",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
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
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorId\": \"Vendor Id \" \n}",
          "type": "json"
        }
      ]
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
  },
  {
    "type": "post",
    "url": "v1/GetVendorOrders",
    "title": "Get Vendor Orders",
    "name": "GetVendorOrders",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "orderStatusId",
            "description": "<p>Order Status Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "pageNumber",
            "description": "<p>Page Number.</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "recordsPerPage",
            "description": "<p>Records Per Page.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorId\": \"Vendor Id\",\n  \"orderStatusId\": \"Status of the order\",\n  \"pageNumber\": \"Page number\",\n  \"recordsPerPage\": \"Number of records per page\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  {\n   \"Data\": {\n     \"__type\": \"Vendor:#Tasko.Model\",\n     \"AddressDetails\": {\n       \"Address\": \"test\",\n       \"AddressId\": null,\n       \"AddressType\":\"Home\",\n       \"City\": \"Hyderabad\",\n       \"Country\": \"India\",\n       \"Lattitude\": \"1\",\n       \"Locality\": \"KPHB\",\n       \"Longitude\": \"2\",\n       \"Pincode\": \"500072\",\n       \"State\": \"Hyderabad\"\n     },\n     \"BaseRate\": 100,\n     \"DateOfBirth\": \"7/7/2016 1:51:33 PM\",\n     \"EmailAddress\": \"sree@gmail.com\",\n     \"Gender\": 1,\n     \"Id\": \"3BCF0E621CC9FA45B644AD360D3B7E29\",\n     \"IsVendorLive\": false,\n     \"IsVendorVerified\": true,\n     \"MobileNumber\": \"1234567890\",\n     \"Name\": \"Srikanth\",\n     \"NoOfEmployees\": 10,\n     \"Password\": null,\n     \"Photo\": \"\",\n     \"UserName\": \"sree123\",\n     \"VendorDetails\": null,\n     \"VendorServices\": null\n   },\n   \"Error\": false,\n   \"Message\": \"Success\",\n   \"Status\": 200\n }\n}",
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
            "field": "NO_ORDERS_FOR_VENDOR",
            "description": "<p>No orders for vendor</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"No orders for vendor\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/GetVendorOverallRatings",
    "title": "Vendor Overall Ratings",
    "name": "GetVendorOverallRatings",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorId\": \"Vendor Id\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n          \"Data\": {\n                    \"__type\": \"VendorOverallRating:#Tasko.Model\",\n                    \"Courtesy\": 3,\n                    \"OverAllRating\": 3,\n                    \"Price\": 3,\n                    \"Punctuality\": 2,\n                    \"ServiceQuality\": 3\n                  },\n          \"Error\": false,\n          \"Message\": \"Success\",\n          \"Status\": 200\n        }",
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
            "field": "NO_RATINGS_FOR_VENDOR",
            "description": "<p>No ratings for vendor</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"No ratings for vendor\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/GetVendorRatings",
    "title": "Get Vendor Ratings",
    "name": "GetVendorRatings",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorId\": \"Vendor Id\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"VendorRating:#Tasko.Model\",\n              \"Comments\": \"Service is Good\",\n              \"Courtesy\": 3,\n              \"CustomerId\": null,\n              \"CustomerName\": \"Shivaji123\",\n              \"Id\": \"342CA9BFFA1F2E419FADB343C7DE3EE7\",\n              \"OverAllRating\": 0,\n              \"Price\": 4,\n              \"Punctuality\": 1,\n              \"ReviewDate\": \"2016-07-01 05:50:19\",\n              \"ServiceQuality\": 5,\n              \"VendorId\": null\n            },\n            {\n              \"__type\": \"VendorRating:#Tasko.Model\",\n              \"Comments\": \"Service is in time\",\n              \"Courtesy\": 3,\n              \"CustomerId\": null,\n              \"CustomerName\": \"Shivaji123\",\n              \"Id\": \"FD388BB73B94644889EA5C56A1163554\",\n              \"OverAllRating\": 0,\n              \"Price\": 4,\n              \"Punctuality\": 2,\n              \"ReviewDate\": \"2016-07-01 05:50:19\",\n              \"ServiceQuality\": 2,\n              \"VendorId\": null\n            }\n          ],\n\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "NO_RATINGS_FOR_VENDOR",
            "description": "<p>No ratings for vendor.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"No ratings for vendor\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/GetVendorServices",
    "title": "Get Vendor services",
    "name": "GetVendorServices",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
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
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorId\": \"Vendor Id \" \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n                \"__type\": \"VendorService:#Tasko.Model\",\n                 \"Id\": \"CF9A27B3DA0D5E418B1A8E6CC79218AD\",\n                 \"ImageURL\": \"\",\n                 \"IsActive\": true,\n                 \"Name\": \"Microwave Service\"\n            }\n         ]\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "NO_SERVICES_AVAILABLE",
            "description": "<p>No services available.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"No services available\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/GetVendorSubServices",
    "title": "Get Vendor sub services",
    "name": "GetVendorSubServices",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "vendorServiceId",
            "description": "<p>Vendor Service Id.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorServiceId\": \"Vendor Service Id to get the sub services \" \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": [\n            {\n              \"__type\": \"VendorService:#Tasko.Model\",\n              \"Id\": \"82B4B5E0C2ACED43BC5233F1A715071B\",\n              \"ImageURL\": \"\",\n              \"IsActive\": true,\n              \"Name\": \"test2\"\n            },\n            {\n              \"__type\": \"VendorService:#Tasko.Model\",\n              \"Id\": \"BFD1E3C77DE53D4E9026DB99FC71CA83\",\n              \"ImageURL\": \"\",\n              \"IsActive\": true,\n              \"Name\": \"test\"\n            }\n          ],\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "NO_SUB_SERVICES_AVAILABLE",
            "description": "<p>No sub services available.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"No sub services available\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/Login",
    "title": "Vendor Login",
    "name": "Login",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Auth_Code",
            "description": "<p>Auth Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Auth_Code\": \"API Key\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "username",
            "description": "<p>User name to login.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "password",
            "description": "<p>password of the user.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "mobilenumber",
            "description": "<p>mobile number of the user.</p>"
          },
          {
            "group": "Parameter",
            "type": "Int16",
            "optional": false,
            "field": "userType",
            "description": "<p>user type.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"username\": \"User name to login\",\n  \"password\": \"Password of the user\",\n  \"mobilenumber\": \"Mobile number of the user\",\n  \"userType\": \"User type\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": {\n             \"__type\": \"LoginInfo:#Tasko.Model\",\n             \"TokenId\": \"6CEC15B7B6FC23439AC131F54551BB22\",\n             \"UserId\": \"FC73EC7242E28142ACCAFDF4703F0EBF\"\n          }\n },\n  \"Error\": false,\n  \"Message\": \"Login Successfull\",\n  \"Status\": 200\n}",
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
            "field": "Authentication",
            "description": "<p>failed.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Authentication failed\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/Logout",
    "title": "Log out",
    "name": "Logout",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"User_Id\": \"Logged in User ID\",\n  \"Content-Type\": \"application/json\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": \"null\",\n },\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "Authentication",
            "description": "<p>failed.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Error logging out\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/StoreVendorGCMUser",
    "title": "Store Vendor GCM User",
    "name": "StoreVendorGCMUser",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "name",
            "description": "<p>GCM User Name .</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "gcmRedId",
            "description": "<p>GCMREDID.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorId\":\"Vendor Id\",\n            \"name\": \"srikanth\",\n            \"gcmRedId\": \"gcm reg Id\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": \"0C12E1E9EF74CD499EAAEDB8FFDCE74A\",\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "USER_NAME_EXISTS",
            "description": "<p>User Name Exists</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"User Name Exists\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/UpdateOrderStatus",
    "title": "Update Order Status",
    "name": "UpdateOrderStatus",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "orderId",
            "description": "<p>Order Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "Short",
            "optional": false,
            "field": "orderStatus",
            "description": "<p>Order Status.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "comments",
            "description": "<p>Comments.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"orderId\": \"Order Id to update the status\",\n  \"orderStatus\": \"Order status \",\n  \"comments\": \"Comments\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "ERROR_UPDATING_ORDER_STATUS",
            "description": "<p>Error while updating OrderStatus.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Error while updating OrderStatus\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/UpdateVendor",
    "title": "Update Vendor",
    "name": "UpdateVendor",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Vendor",
            "optional": false,
            "field": "vendor",
            "description": "<p>Vendor.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendor\": \"Vendor details to update\" \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/UpdateVendorBaseRate",
    "title": "Update Vendor Base Rate",
    "name": "UpdateVendorBaseRate",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "double",
            "optional": false,
            "field": "baseRate",
            "description": "<p>Base Rate.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorId\": \"Vendor Id\",\n  \"baseRate\": \"Base Rate\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "{\n \"Data\": null,\n \"Error\": false,\n \"Message\": \"Success\",\n \"Status\": 200\n}",
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
            "field": "ERROR_UPDATING_VENDOR_BASE_RATE",
            "description": "<p>Error while updating Vendor Base Rate.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Error while updating Vendor Base Rate\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/UpdateVendorLocation",
    "title": "Update Vendor Location",
    "name": "UpdateVendorLocation",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "vendorId",
            "description": "<p>Vendor Id.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "longitude",
            "description": "<p>Longitude of Vendor.</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "latitude",
            "description": "<p>Latitude of Vendor.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n   \"latitude\": \"17.3850440\",\n             \"longitude\": \"78.4866710\",\n             \"vendorId\":\"F3E6D9CBF8EF6A4289E1FC3509076D54\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "INVALID_TOKEN_CODE",
            "description": "<p>Invalid token code</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Invalid token code\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/UpdateVendorServices",
    "title": "Update Vendor Services",
    "name": "UpdateVendorServices",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Token_Code",
            "description": "<p>Token Code</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "Content-Type",
            "description": "<p>application/json</p>"
          },
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "User_Id",
            "description": "<p>User Id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"Token_Code\": \"Unique Token code that is generated after login\" ,\n  \"Content-Type\": \"application/json\"\n  \"User_Id\": \"Logged in User ID\",\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "List",
            "optional": false,
            "field": "vendorServices",
            "description": "<p>List of Vendor Services.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Param-Example:",
          "content": "{\n  \"vendorServices\": [\n {\n     \"__type\": \"VendorService:#Tasko.Model\",\n     \"Id\": \"196898FF2956FE478FB4FD9C2A8B49F6\",\n     \"ImageURL\": \"\",\n     \"IsActive\": true,\n     \"Name\": \"Carpentry\"\n },\n {\n     \"__type\": \"VendorService:#Tasko.Model\",\n     \"Id\": \"8B9BDFDF712B764E88FF29E8733A92C2\",\n     \"ImageURL\": \"\",\n     \"IsActive\": false,\n     \"Name\": \"Pest Control\"\n },\n {\n     \"__type\": \"VendorService:#Tasko.Model\",\n     \"Id\": \"9B41B620DFDFD24D8A861BFB96827DDD\",\n     \"ImageURL\": \"\",\n     \"IsActive\": true,\n     \"Name\": \"Microwave Service\"\n },\n {\n     \"__type\": \"VendorService:#Tasko.Model\",\n     \"Id\": \"E0311E79F6785541B6E008721A4B41BA\",\n     \"ImageURL\": \"\",\n     \"IsActive\": true,\n     \"Name\": \"Refrigerator Service\"\n },\n {\n     \"__type\": \"VendorService:#Tasko.Model\",\n     \"Id\": \"FB282BF584AB1145B73FB35CB8589C1E\",\n     \"ImageURL\": \"\",\n     \"IsActive\": true,\n     \"Name\": \"Plumber\"\n   }\n  ],\n }",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response: ",
          "content": " {\n  \"Data\": null,\n  \"Error\": false,\n  \"Message\": \"Success\",\n  \"Status\": 200\n}",
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
            "field": "ERROR_UPDATING_VENDOR_SERVICES",
            "description": "<p>Error while updating Vendor Services.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Error while updating Vendor Services\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  },
  {
    "type": "post",
    "url": "v1/auth",
    "title": "Get Auth Code",
    "name": "auth",
    "group": "Vendor",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "string",
            "optional": false,
            "field": "X-APIKey",
            "description": "<p>API Key</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Header-Example:",
          "content": "{\n  \"X-APIKey\": \"API Key\" ,\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": " {\n  \"Data\": \"API key comes here\",\n  \"Error\": false,\n  \"Message\": \"Authentication Successful\",\n  \"Status\": 200\n}",
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
            "field": "Authentication",
            "description": "<p>failed.</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": " {\n  \"Data\": null,\n  \"Error\": true,\n  \"Message\": \"Authentication failed\",\n  \"Status\": 400\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Interfaces/IVendorAppService.cs",
    "groupTitle": "Vendor"
  }
] });
