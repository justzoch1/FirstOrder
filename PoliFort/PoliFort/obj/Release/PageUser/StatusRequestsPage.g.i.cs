﻿#pragma checksum "..\..\..\PageUser\StatusRequestsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6C3EF322F04B4C8A80D56D2AAF4B9239640499F23567A7F41AE57D2FEA7EC082"
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
using PoliFort.PageUser;
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


namespace PoliFort.PageUser {
    
    
    /// <summary>
    /// StatusRequestsPage
    /// </summary>
    public partial class StatusRequestsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Chip Roll;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search_Textbox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Chip GetOutChip;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Chip Search_Chip;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView usersList;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Chip GotoSecond;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxCode;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFeedback;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\PageUser\StatusRequestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.RatingBar ratingBar;
        
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
            System.Uri resourceLocater = new System.Uri("/PoliFort;component/pageuser/statusrequestspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PageUser\StatusRequestsPage.xaml"
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
            this.Roll = ((MaterialDesignThemes.Wpf.Chip)(target));
            
            #line 20 "..\..\..\PageUser\StatusRequestsPage.xaml"
            this.Roll.Click += new System.Windows.RoutedEventHandler(this.Roll_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Search_Textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\PageUser\StatusRequestsPage.xaml"
            this.Search_Textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_Textbox_Changed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GetOutChip = ((MaterialDesignThemes.Wpf.Chip)(target));
            
            #line 25 "..\..\..\PageUser\StatusRequestsPage.xaml"
            this.GetOutChip.Click += new System.Windows.RoutedEventHandler(this.Click_Chip_GoOut);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Search_Chip = ((MaterialDesignThemes.Wpf.Chip)(target));
            return;
            case 5:
            this.usersList = ((System.Windows.Controls.ListView)(target));
            
            #line 30 "..\..\..\PageUser\StatusRequestsPage.xaml"
            this.usersList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.usersList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.GotoSecond = ((MaterialDesignThemes.Wpf.Chip)(target));
            
            #line 42 "..\..\..\PageUser\StatusRequestsPage.xaml"
            this.GotoSecond.Click += new System.Windows.RoutedEventHandler(this.GotoSecond_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBoxCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TextBoxFeedback = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.ratingBar = ((MaterialDesignThemes.Wpf.RatingBar)(target));
            return;
            case 10:
            
            #line 50 "..\..\..\PageUser\StatusRequestsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Request_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

