﻿#pragma checksum "..\..\..\windows\WindowBasket.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7906992FCE8595DA6A771389E4E98AC2180C49442C2B23E9194174320449B6B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WriteErase;


namespace WriteErase {
    
    
    /// <summary>
    /// WindowBasket
    /// </summary>
    public partial class WindowBasket : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 24 "..\..\..\windows\WindowBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbFIO;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\windows\WindowBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListProd;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\windows\WindowBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbSum;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\windows\WindowBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbSumDiscount;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\windows\WindowBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPickPoint;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\windows\WindowBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCanel;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\windows\WindowBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOrder;
        
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
            System.Uri resourceLocater = new System.Uri("/WriteErase;component/windows/windowbasket.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\windows\WindowBasket.xaml"
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
            this.tbFIO = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ListProd = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.tbSum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.tbSumDiscount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.cbPickPoint = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnCanel = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\..\windows\WindowBasket.xaml"
            this.btnCanel.Click += new System.Windows.RoutedEventHandler(this.btnCanel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnOrder = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\windows\WindowBasket.xaml"
            this.btnOrder.Click += new System.Windows.RoutedEventHandler(this.btnOrder_Click);
            
            #line default
            #line hidden
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
            case 3:
            
            #line 57 "..\..\..\windows\WindowBasket.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbKolvo_TextChanged);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\windows\WindowBasket.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbKolvo_PreviewTextInput);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 60 "..\..\..\windows\WindowBasket.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.bDelete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

