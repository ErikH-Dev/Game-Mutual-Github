using AutoMapper;
using DAL.DBContext;
using DAL.ErrorHelper;
using DAL.Models;
using Exceptions.DbExceptions;
using Logic.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedObjects;

namespace DAL
{
	public class UserDAL : IUserCollection
	{
		private readonly UserDbContext _context;
		private readonly IErrorHelper _errorHelper;
		private readonly IMapper _mapper;

		public UserDAL(UserDbContext context, IErrorHelper errorHelper, IMapper mapper)
		{
			_context = context;
			_errorHelper = errorHelper;
			_mapper = mapper;
		}
		public async Task<IUser> Create(IUser user)
		{
			EntityEntry<UserDTO>? entity = null;
			try
			{
				UserDTO? userDTO = _mapper.Map<UserDTO>(user);
				var existingUser = await ReadByToken(user.Subject);
				if (existingUser != null)
				{
					return existingUser;
				}
				entity = await _context.Users.AddAsync(userDTO);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_errorHelper.HandleError(ex);
			}
			return entity.Entity ?? throw new UnableToCreateObjectException("Unable to create user");
		}
		public async Task<IUser> ReadByToken(string subjectToken)
		{
			IUser? result = null;
			try
			{
				result = await _context.Users.FirstOrDefaultAsync(p => p.Subject == subjectToken);
			}
			catch (Exception ex)
			{
				_errorHelper.HandleError(ex);
			}
			return result;
		}
		public async Task<IUser> Read(int id)
		{
			IUser? result = null;
			try
			{
				result = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
			}
			catch (Exception ex)
			{
				_errorHelper.HandleError(ex);
			}
			return result ?? throw new ObjectNotFoundException("Object not found, with id: " + id);
		}
		public async Task<IUser> Update(IUser user)
		{
			try
			{
				_context.Entry(user).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_errorHelper.HandleError(ex);
			}
			return await Read(user.Id) == user ? user : throw new UnableToUpdateObjectException("Unable to update, with id: " + user.Id);
		}
		public async Task<bool> Delete(int id)
		{
			try
			{
				IUser user = await Read(id);
				if (user == null)
				{
					return false;
				}
				_context.Users.Remove((UserDTO)user);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				_errorHelper.HandleError(ex);
				return false;
			}
		}
		public async Task<bool> AddSteamId(int userId, string steamId)
		{
			try
			{
				IUser user = await Read(userId);
				user.SteamId = steamId;
				await Update(user);
				return true;
			}
			catch (Exception ex)
			{
				_errorHelper.HandleError(ex);
				return false;
			}
		}
	}
}
