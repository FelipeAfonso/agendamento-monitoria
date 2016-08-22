using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Controller {

    public static String getMd5(String s) {
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(s);
        byte[] hash = md5.ComputeHash(inputBytes);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < hash.Length; i++) { sb.Append(hash[i].ToString("X2")); }
        return sb.ToString();
    }

}