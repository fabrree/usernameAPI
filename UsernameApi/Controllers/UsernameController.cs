using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecuringWebApiUsingApiKey.Attributes;
using UsernameApi.Models;

namespace UsernameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [ApiKey]
    public class UsernameController : ControllerBase
    {
        private static readonly string[] bijvNw = new[]
        {
           "Lange","Kleine","Dunne","Dikke", "Oranje", "Rode","Gele","Groene","Blauwe" , "Paarse", "Roze", "Bruine", "Grijze", "Slimste","Rode","Zachte","Vriendelijke","Vieze","Verstandige","Veilige","Snelle","Nuttige","Mooie","Kalme","Goedkope","Gelukkige","Ernstige","Bijzondere","Boze","Beroemde", "Arme", "Amusante", "Dolle", "Enige", "Geinige", "grappige", "Lollige", "Mieterse", "Moppige", "Vrolijke", "Prettige", "Toffe", "Vermakelijk", "Lieve", "Mooie", "Belangrijke","Wilde"
        };
        private static readonly string[] daarna = new[]
        {
        "Aap", "Beer", "Cavia","Chinchilla", "Das", "Broekzak", "Dolfijn", "Duif", "eend", "Eland", "Ezel", "Fazant", "Fret", "Gans", "Geit", "Giervalk", "Giraffe", "Haas", "Haring", "Hert", "Kip", "Honingbij", "Hond", "Jachtluipaard", "Kanarie", "Kalkoen", "Kat", "Kikker", "Konijn", "Tor", "Kraai", "Mug", "Leeuw", "Muis", "Neushoorn","Paling","Parkiet","Rat","Ree","Rund","Schaap","Valk", "Tijger","Uil","Vis","Vlieg","Vlinder","Vos","Walvis","Zwijn","Wolf","Zeehond","Uitvinder","Visser","Vuilnisman","Ijscoman","Zweminstructeur","Zilversmid", "Aannemer", "Acteur", "Agent", "Arts", "Automonteur", "Bakker", "Bewaker", "Boswachter", "Buikspreker","Chefkok", "Clown", "Detective","Duiker", "Fotograaf", "Generaal", "Gitarist", "Glasblazer","Hoefsmid","Huisarts","Juwelier","Kapper","Kok","Matroos","Metselaar","Ober","Piloot","Professor","Schipper","Schoonmaker","Tegelzetter","Tolk","Tuinman"
        };

        private string RandomName()
        {
            Random random = new Random();
            var deel1 = bijvNw[random.Next(0, bijvNw.Length)];
            var deel2 = daarna[random.Next(0, daarna.Length)];
            var deel3 = random.Next(0, 9999);

            var result = deel1 + deel2 + deel3;
            System.Console.WriteLine(result);
            return result;

        }

        //4230 combinaties  + met random getal tot 9999 = 42.295.770 combinaties :)
        private readonly DbContext _context;

        public UsernameController(DbContext context)
        {
            _context = context;
        }


        // GET: api/Username
        [HttpGet("{key}")]
        public async Task<ActionResult<UsernameDTO>> GetUsername(int key)
        {

            try
            {
                var valid = await _context.ApiKeys.FirstAsync(x => x.Code == key);
                if (valid == null)
                {
                    return Content("Suck a cock");
                    //return NotFound("loser");
                }

               var randomName = RandomName();


                while (await _context.Usernames
                    .Include(x => x.ApiKey)
                    .AnyAsync(x => x.Name.Equals(randomName)
                    && x.ApiKey.Code == key))
                {
                    randomName = RandomName();
                }

                var name = new Username
                {
                    Name = randomName,
                    ApiKey = valid
                };

                _context.Usernames.Add(name);
                await _context.SaveChangesAsync();
                return usernameToDTO(name);
            }
            catch(Exception ex)
            {
                return StatusCode(500, " #PascalHaatJe -> decode dit NU (decimal to text decoder): 108 111 115 101 114  104 97 104 97  106 105 106  108 111 115 101 114 46  66 101 115 116 101 108  112 105 122 122 97  118 111 111 114  82 97 111 117 108");
            }



        }

        private static UsernameDTO usernameToDTO(Username username) =>
            new UsernameDTO
            {
                Name = username.Name
            };
    }
}
