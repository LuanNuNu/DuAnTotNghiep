﻿#pragma checksum "..\..\..\Views\DichVu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D3B108C39F4FF913ECEFB8C9528E1D7260F3DF06179FCF9C705118BF223B25D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DuAn_QuanLiKhachSan.Views;
using FontAwesome.Sharp;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace DuAn_QuanLiKhachSan.Views {
    
    
    /// <summary>
    /// DichVu
    /// </summary>
    public partial class DichVu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 1 "..\..\..\Views\DichVu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DuAn_QuanLiKhachSan.Views.DichVu ___No_Name_;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\DichVu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_searchRoom;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\DichVu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_dichVu;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Views\DichVu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridDV;
        
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
            System.Uri resourceLocater = new System.Uri("/DuAn_QuanLiKhachSan;component/views/dichvu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\DichVu.xaml"
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
            this.___No_Name_ = ((DuAn_QuanLiKhachSan.Views.DichVu)(target));
            
            #line 9 "..\..\..\Views\DichVu.xaml"
            this.___No_Name_.Loaded += new System.Windows.RoutedEventHandler(this.___No_Name__Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_searchRoom = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\Views\DichVu.xaml"
            this.txt_searchRoom.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_searchRoom_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_dichVu = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Views\DichVu.xaml"
            this.btn_dichVu.Click += new System.Windows.RoutedEventHandler(this.btn_dichVu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataGridDV = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 36 "..\..\..\Views\DichVu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_btn_Click);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 39 "..\..\..\Views\DichVu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Xoa_btn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

