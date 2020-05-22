using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using schedule.Entities;
using schedule.Enums;
using schedule;
using System.Windows;

namespace ScheduleInterface
{
    class MainWindowViewModel
    {
        public ObservableCollection<Class> Classes { get; set; }
        public bool IsDatabaseChecked { get; set; }
        public bool IsFileChecked { get; set; }
        public bool RadioButCheck { get; set; } = true;
        private ProgramMode programMode;
        private Schedule schedule;
        public ICommand CreateCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public MainWindowViewModel()
        {
            CreateCommand = new DelegateCommand(Create);
            ShowCommand = new DelegateCommand(Show);
            Classes = new ObservableCollection<Class>();
            schedule = new Schedule();
        }
        private void SetProgramMode()
        {
            if(IsDatabaseChecked && IsFileChecked)
            {
                programMode = ProgramMode.Both;
            }
            else if(IsDatabaseChecked)
            {
                programMode = ProgramMode.Database;
            }
            else
            {
                programMode = ProgramMode.XML;
            }
        }
        public void Create(object o)
        {
            SetProgramMode();
            schedule.CreateSchedule(programMode);
            MessageBox.Show("Schedule is ready", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Show(object o)
        {
            if(RadioButCheck && (programMode == ProgramMode.Both || programMode == ProgramMode.Database))
            {
                foreach (var item in ClassRepo.GetClassesFromDb())
                {
                    Classes.Add(item);
                }
                //Classes = new ObservableCollection<Class>(schedule.Classes);
            }
            else if(!RadioButCheck && programMode == ProgramMode.XML)
            {
                schedule.FormClassesByID();
                Classes = new ObservableCollection<Class>(schedule.Classes);
            }
            else
            {
                MessageBox.Show("I think you've done something wrong :)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
