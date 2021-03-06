﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FolderBackup.Shared
{
    public static class AuthenticationPrimitives
    {
        static public string hashPassword(string password, string salt, string token)
        {
            return Hash(Hash(Hash(password) + salt) + token);
        }

        static public string hashPassword(string password, string salt)
        {
            return Hash(Hash(password) + salt);
        }

        static private string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
