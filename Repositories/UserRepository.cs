using EcommerceDB.Context;
using EcommerceDB.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repositories
{
    public class UserRepository :MainRepository<User>
    {
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        public UserRepository(EcommerceDBContext dBContext, UserManager<User> _userManager, SignInManager<User> _signInManager) : base(dBContext)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }


        public async Task<IdentityResult> Register(UserRegisterViewModel viewModel)
        {
            User user = new User
            {
                FullName = viewModel.FullName,
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                //PasswordHash
            };

            IdentityResult res = await userManager.CreateAsync(user,viewModel.Password);
            return res;
        }

        public async Task<SignInResult> Login(UserLoginViewModel viewModel)
        {
            var user = await userManager.FindByEmailAsync(viewModel.Email);
            if (user != null)
            {
                SignInResult res = await signInManager
                    .PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, true);
                return res;
            }
            else
                return new SignInResult();

        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        
    }
}
