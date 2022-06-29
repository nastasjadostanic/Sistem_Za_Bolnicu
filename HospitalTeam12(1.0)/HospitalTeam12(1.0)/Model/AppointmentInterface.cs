using System;
using System.Collections.Generic;
using System.Text;
using MainPackage.Model;
using System.Collections;

namespace MainPackage.Model
{
    public abstract class AppointmentInterface<T>
    {
        public abstract Boolean Schedule(T obj);
        public abstract ArrayList ViewAll();
        public abstract Boolean Reschedule(T obj);
        public abstract Boolean Remove(String s);
    }
}
