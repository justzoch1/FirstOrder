﻿#pragma checksum "..\..\..\MainWindow\AddAccountWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "22B0929F2ACBBE65541E6778D9E191AEBA25EE8DF90CF4A9718E7D6EC2FF0734"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PoliFort;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PoliFort {
    
    
    /// <summary>
    /// AddAccountWindow
    /// </summary>
    public partial class AddAccountWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\MainWindow\AddAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_New_Login;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\MainWindow\AddAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_New_Passwword;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow\AddAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox YourRole;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PoliFort;component/mainwindow/addaccountwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow\AddAccountWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\MainWindow\AddAccountWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_Back_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBox_New_Login = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\MainWindow\AddAccountWindow.xaml"
            this.TextBox_New_Login.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Login_New_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBox_New_Passwword = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\MainWindow\AddAccountWindow.xaml"
            this.TextBox_New_Passwword.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Password_New_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.YourRole = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\MainWindow\AddAccountWindow.xaml"
            this.YourRole.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

