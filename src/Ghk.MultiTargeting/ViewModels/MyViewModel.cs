// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyViewModel.cs" company="Geert van Horrik">
//   Copyright (c) 2008 - 2018 Geert van Horrik. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Ghk.MultiTargeting.ViewModels
{
    using Catel.MVVM;

    public class MyViewModel : ViewModelBase
    {
        public MyViewModel()
        {
            Title = "Pure magic!";
        }

        public string Scope { get; set; }
    }
}