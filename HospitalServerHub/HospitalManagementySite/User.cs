using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementySite
{
    public class User
    {


        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        //id

        public string UserId { get; set; }



        [BsonElement("username"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string Username { get; set; }



        [BsonElement("password"), BsonRepresentation(MongoDB.Bson.BsonType.String)]


        public string Password { get; set; }





        [BsonElement("firstName"), BsonRepresentation(MongoDB.Bson.BsonType.String)]


        public string FirstName { get; set; }

        [BsonElement("lastName"), BsonRepresentation(MongoDB.Bson.BsonType.String)]


        public string LastName { get; set; }


        [BsonElement("phoneNumber"), BsonRepresentation(MongoDB.Bson.BsonType.String)]


        public string PhoneNumber { get; set; }


        [BsonElement("email"), BsonRepresentation(MongoDB.Bson.BsonType.String)]


        public string Email { get; set; }


        [BsonElement("accessLevel"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]


        public int AccessLevel { get; set; }



    }
}
