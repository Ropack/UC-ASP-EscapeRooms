﻿using System;
using UC.CSP.MeetingCenter.DAL;

namespace US.ASP.EscapeRooms.DAL
{
    public class AppUnitOfWorkProvider
    {
        public static AppUnitOfWorkProvider Instance { get; private set; }

        static AppUnitOfWorkProvider()
        {
            Instance = new AppUnitOfWorkProvider();
        }

        private AppUnitOfWork CurrentUoW { get; set; }

        private AppUnitOfWorkProvider()
        {
            
        }
        public AppUnitOfWork Create()
        {
            CurrentUoW = new AppUnitOfWork();
            CurrentUoW.Disposing += (sender, args) => { CurrentUoW = null; };
            return CurrentUoW;
        }

        public AppUnitOfWork GetCurrent()
        {
            if (CurrentUoW == null)
            {
                throw new InvalidOperationException("The Repository or Query must be used in a unit of work of type AppUnitOfWork!");
            }
            return CurrentUoW;
        }
    }
}