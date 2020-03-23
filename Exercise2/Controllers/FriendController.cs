using System;
using System.Data;
using Exercise2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Exercise2.Controllers
{
    public class FriendController : Controller
    {
        readonly string ConnectionInformation = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=adocrud;Integrated Security=true";
        

        /*core
        private readonly Data _db;
        public FriendController(Data db)
        {
           this. _db = db;
        }*/
        public IActionResult InsertNewFriend()
        {
            return View();
        }
        //public IActionResult Index()
        //{
        //    var friend = _db.friends.ToArray();
        //    return View();
        //}
       [HttpPost,Route("Post")]
        public IActionResult Post(String FriendId , String FriendName, String Place)
        {
            Friend friend = new Friend();
            friend.FriendId =long.Parse( FriendId);
            friend.FriendName = FriendName;
            friend.Place = Place;

            SqlConnection MainConnection = new SqlConnection(ConnectionInformation);
            MainConnection.Open();
            string MyCommand = "Insert Into Friends(FriendId,FriendName,Place) values("+friend.FriendId+",'"+friend.FriendName+"','"+friend.Place+"')";
            SqlCommand myCommand = new SqlCommand(MyCommand,MainConnection);
            myCommand.ExecuteNonQuery();

            MainConnection.Close();
           


          
            return View();
        }

//update function
        [Route("Post")]
        public IActionResult Get(String FriendId, String FriendName, String Place)
        {
            Friend friend = new Friend();
            friend.FriendId = long.Parse(FriendId);
            friend.FriendName = FriendName;
            friend.Place = Place;

            SqlConnection MainConnection = new SqlConnection(ConnectionInformation);
            MainConnection.Open();
            //            string MyCommand = "Insert Into Friends(FriendId,FriendName,Place) values("+friend.FriendId+",'"+friend.FriendName+"','"+friend.Place+"')";
            string MyCommand = "Update Friends SET FriendName='" + friend.FriendName + "',Place='" + friend.Place + "' where FriendId=" + friend.FriendId;

            SqlCommand myCommand = new SqlCommand(MyCommand, MainConnection);
            myCommand.ExecuteNonQuery();

            MainConnection.Close();*/

            /*core
            //Friend friend = new Friend();
            //friend.FriendId =long.Parse( FriendId);
            //friend.FriendName = FriendName;
            //friend.Place = Place;
            //_db.friends.Add(friend);
            //_db.SaveChanges();
            



            return View();
        }
        [Route("select")]
        public IActionResult select()
        {
            

            SqlConnection MainConnection = new SqlConnection(ConnectionInformation);
            MainConnection.Open();
            string MyCommand = "select * from Friends";
            SqlCommand myCommand = new SqlCommand(MyCommand, MainConnection);
            //myReader=  myCommand.ExecuteReader();
            SqlDataAdapter adp = new SqlDataAdapter(MyCommand, MainConnection);
            DataTable dt = new DataTable();
            adp.Fill(dt);
           // while (myReader.Read())
            //{
                //Friend friends = new Friend();
                //friends.FriendId = Int32.Parse(myReader.GetValue(0).ToString());
                //friends.FriendName = myReader.GetValue(1).ToString();
                //friends.Place = myReader.GetValue(2).ToString();
                //model.Add(friends);
              

            //}

            MainConnection.Close();
            return View(dt);
            //return View();
        }
    } 
}