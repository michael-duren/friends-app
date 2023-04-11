using Microsoft.EntityFrameworkCore;
using FriendsApp.FriendModels;
namespace FriendsApp.Data;

public class FriendsContext : DbContext
{
		public DbSet<FriendModel> Friends { get; set; }	= null!;	

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
				optionsBuilder.UseSqlite("Data Source=Friends.db");
		}
}