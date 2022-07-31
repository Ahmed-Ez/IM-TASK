using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IM_Task.API.APIControllers
{
    public class PalindromeController : ApiController
    {
        [HttpPost]
        [Route("api/Palindrome/IsPalindrome")]
        public IHttpActionResult IsPalindrome([FromBody] string text)
        {
            try
            {
                // remove white spaces from text
                text = text.Replace(" ", "");
                // change text to lower case
                text = text.ToLower();

                for (int i = 0; i < text.Length / 2; i++)
                {
                    if (text[i] != text[text.Length - i - 1])
                        return Ok(false);
                }
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        [Route("api/Plaindrome/IsPalindromeSql")]
        public IHttpActionResult IsPalindromeSql([FromBody] string text)
        {
            try
            {
                // Here I am using a simple database connection as we don't need to actually query anything from database
                // I am also using a simple sql query that can be turned into an sql function or a stored procedure but this one is very simple So I used the query directly 
                // In the query I could next the Replace, Lower and Reverse methods, but I left them separated for clarity
                var connectionString = ConfigurationManager.ConnectionStrings["IM"].ToString();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand($@"declare @string nvarchar(255);
            set @string = '{text}';
            set @string = REPLACE(@string,' ','');
            set @string = LOWER(@string);
            SELECT CASE WHEN @string=REVERSE(@string)THEN 'True'
            ELSE 'False'
            END  ", cn);

                    var res = cmd.ExecuteScalar();

                    return Ok(System.Convert.ToBoolean(res));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            }
        }

    }