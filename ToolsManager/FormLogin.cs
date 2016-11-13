﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //async Task<string> test()//模拟异步方法调用
        //{
        //    int i = 0;
        //    Action Act = delegate ()
        //    { Thread.Sleep(1000); i += 1000; };
        //    for (int a = 0; a < 5; a++)
        //    {
        //        await Task.Factory.StartNew(Act);
        //        Debug.WriteLine("等待了" + i.ToString() + "毫秒");
        //    }
        //    return "5000毫秒等待后返回结果";
        //}

        async private void btn_login_Click(object sender, EventArgs e)
        {

#if DEBUG
            Debug.WriteLine("使用默认账号yyq登录调试");
            tx_username.Text = "yyq";
            tx_password.Text = "123456";
#endif

            Global.formLoading.Show();
            var result = await Server.Login(tx_username.Text, tx_password.Text);

            

            if (result)
            {
                //登录成功
                if (Global.formMain == null)
                {
                    Global.formMain = new FormMain();
#if DEBUG
                    Global.formMain.TopMost = false;
                    Global.formMain.FormBorderStyle = FormBorderStyle.FixedDialog;
#else
                    Global.formMain.TopMost = true;
#endif
                    Global.formMain.Show();
                    this.Hide();
                }else
                {

                }
            }
            else
            {
                //登录失败
            }
Global.formLoading.Hide();

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.formLogin = null;
        }
    }
}
