using System;
namespace BookApp.Models
{
    public class OrderInputModel
    {
        public int amount {get; set;}
        public string UserId {get;set;}
        public DateTime ExpirationTime {get; set;}
        public int BookId {get;set;}
    }
}