﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (Session["user_email"] != null) { LoginForm.Visible = false; }
    }
}