namespace HotChocolateWithAspIdentity.Infrastructure.Persistence
{
	public class ApplicationDbContextInitialiser
	{
		private readonly ApplicationDbContext _context;

		public ApplicationDbContextInitialiser(ApplicationDbContext context)
		{
			_context = context;
		}
	}
}
