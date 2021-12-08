using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDatabase.Document;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDatabase.Queries {
    internal static class InsertData {
        public static async Task Insert() {
            var persona = new List<Persona> {
                new Persona {
                    Id = new ObjectId(),
                    Name = "asier",
                    SubName = "garcia",
                    FechaNacimiento = new DateTime(1997, 08, 27)
                },
                new Persona {
                    Id = new ObjectId(),
                    Name = "asier",
                    SubName = "garcia",
                    FechaNacimiento = new DateTime(1997, 08, 27)
                },
                new Persona {
                    Id = new ObjectId(),
                    Name = "asier",
                    SubName = "garcia",
                    FechaNacimiento = new DateTime(1997, 08, 27)
                },
                new Persona {
                    Id = new ObjectId(),
                    Name = "asier",
                    SubName = "garcia",
                    FechaNacimiento = new DateTime(1997, 08, 27)
                },
                new Persona {
                    Id = new ObjectId(),
                    Name = "asier",
                    SubName = "garcia",
                    FechaNacimiento = new DateTime(1997, 08, 27)
                }
            };
            await Helper.GetConnectionDatabase.GetCollection<Persona>("persona").InsertManyAsync(persona);
        }
    }
}
