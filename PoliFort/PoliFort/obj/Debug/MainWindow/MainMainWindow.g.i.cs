﻿#pragma checksum "..\..\..\MainWindow\MainMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8F522F9B5BE010B8E392FC227C8F8225ACC6C03EA861AAE8A4D462811F308734"
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
    /// MainMainWindow
    /// </summary>
    public partial class MainMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\MainWindow\MainMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid phonesGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow\MainMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn one_bind;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\MainWindow\MainMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search_Textbox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MainWindow\MainMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Chip GetOutChip;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\MainWindow\MainMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Chip Search_Chip;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MainWindow\MainMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combobox_Table;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\MainWindow\MainMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combobox_Filter;
        
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
            System.Uri resourceLocater = new System.Uri("/PoliFort;component/mainwindow/mainmainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow\MainMainWindow.xaml"
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
            this.phonesGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.one_bind = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.Search_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.GetOutChip = ((MaterialDesignThemes.Wpf.Chip)(target));
            
            #line 36 "..\..\..\MainWindow\MainMainWindow.xaml"
            this.GetOutChip.Click += new System.Windows.RoutedEventHandler(this.Click_Chip_GoOut);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Search_Chip = ((MaterialDesignThemes.Wpf.Chip)(target));
            
            #line 38 "..\..\..\MainWindow\MainMainWindow.xaml"
            this.Search_Chip.Click += new System.Windows.RoutedEventHandler(this.Search_Chip_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Combobox_Table = ((System.Windows.Controls.ComboBox)(target));
            
            #line 41 "..\..\..\MainWindow\MainMainWindow.xaml"
            this.Combobox_Table.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combobox_Table_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Combobox_Filter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 50 "..\..\..\MainWindow\MainMainWindow.xaml"
            this.Combobox_Filter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combobox_Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 59 "..\..\..\MainWindow\MainMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 60 "..\..\..\MainWindow\MainMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

