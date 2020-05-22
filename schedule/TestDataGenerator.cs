using schedule.Entities;
using schedule.Enums;
using schedule.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule
{
    static class TestDataGenerator
    {
        public static void GenerateGrours()
        {
            // groups
            Group g1 = GroupRepo.CreateGroup("ПМІ-21", 20);
            GroupRepo.AddToDb(g1);
            Group g2 = GroupRepo.CreateGroup("ПМІ-22", 20);
            GroupRepo.AddToDb(g2);
            Group g3 = GroupRepo.CreateGroup("ПМІ-23", 20);
            GroupRepo.AddToDb(g3);
            Group g4 = GroupRepo.CreateGroup("ПМІ-11", 20);
            GroupRepo.AddToDb(g4);
            Group g5 = GroupRepo.CreateGroup("ПМІ-12", 20);
            GroupRepo.AddToDb(g5);
            Group g6 = GroupRepo.CreateGroup("ПМІ-13", 20);
            GroupRepo.AddToDb(g6);
            Group g7 = GroupRepo.CreateGroup("ПМІ-31", 20);
            GroupRepo.AddToDb(g7);
            Group g8 = GroupRepo.CreateGroup("ПМІ-32", 20);
            GroupRepo.AddToDb(g8);
            Group g9 = GroupRepo.CreateGroup("ПМІ-33", 20);
            GroupRepo.AddToDb(g9);
        }
        public static void GenerateRooms()
        {
            // rooms
            Room r1 = RoomRepo.CreateRoom(ClassType.Ordinary, 366, 25);
            RoomRepo.AddToDb(r1);
            Room r2 = RoomRepo.CreateRoom(ClassType.Lecture, 111, 80);
            RoomRepo.AddToDb(r2);
            Room r3 = RoomRepo.CreateRoom(ClassType.Ordinary, 367, 25);
            RoomRepo.AddToDb(r3);
            Room r4 = RoomRepo.CreateRoom(ClassType.Ordinary, 70, 25);
            RoomRepo.AddToDb(r4);
            Room r5 = RoomRepo.CreateRoom(ClassType.Computer, 1192, 25);
            RoomRepo.AddToDb(r5);
            Room r6 = RoomRepo.CreateRoom(ClassType.Computer, 1191, 25);
            RoomRepo.AddToDb(r6);
            Room r7 = RoomRepo.CreateRoom(ClassType.Ordinary, 73, 25);
            RoomRepo.AddToDb(r7);
            Room r8 = RoomRepo.CreateRoom(ClassType.Computer, 117, 20);
            RoomRepo.AddToDb(r8);
            Room r9 = RoomRepo.CreateRoom(ClassType.Computer, 2723, 20);
            RoomRepo.AddToDb(r9);
            Room r10 = RoomRepo.CreateRoom(ClassType.Computer, 116, 20);
            RoomRepo.AddToDb(r10);
            Room r11 = RoomRepo.CreateRoom(ClassType.Ordinary, 145, 25);
            RoomRepo.AddToDb(r11);
            Room r12 = RoomRepo.CreateRoom(ClassType.Lecture, 439, 120);
            RoomRepo.AddToDb(r12);
            Room r13 = RoomRepo.CreateRoom(ClassType.Ordinary, 266, 25);
            RoomRepo.AddToDb(r13);
            Room r14 = RoomRepo.CreateRoom(ClassType.Ordinary, 365, 25);
            RoomRepo.AddToDb(r14);
            Room r15 = RoomRepo.CreateRoom(ClassType.Computer, 270, 25);
            RoomRepo.AddToDb(r15);
            Room r16 = RoomRepo.CreateRoom(ClassType.Computer, 118, 25);
            RoomRepo.AddToDb(r16);
            Room r17 = RoomRepo.CreateRoom(ClassType.Ordinary, 261, 25);
            RoomRepo.AddToDb(r17);
            Room r18 = RoomRepo.CreateRoom(ClassType.Ordinary, 265, 25);
            RoomRepo.AddToDb(r18);
            Room r19 = RoomRepo.CreateRoom(ClassType.Computer, 273, 25);
            RoomRepo.AddToDb(r19);
        }
        public static void GenerateTeachers()
        {
            // teachers
            Teacher t1 = TeacherRepo.CreateTeacher("Квасниця");
            TeacherRepo.AddToDb(t1);
            Teacher t2 = TeacherRepo.CreateTeacher("Пелюшкевич");
            TeacherRepo.AddToDb(t2);
            Teacher t3 = TeacherRepo.CreateTeacher("Притула");
            TeacherRepo.AddToDb(t3);
            Teacher t4 = TeacherRepo.CreateTeacher("Рикалюк");
            TeacherRepo.AddToDb(t4);
            Teacher t5 = TeacherRepo.CreateTeacher("Жировецький");
            TeacherRepo.AddToDb(t5);
            Teacher t6 = TeacherRepo.CreateTeacher("Стойко");
            TeacherRepo.AddToDb(t6);
            Teacher t7 = TeacherRepo.CreateTeacher("Костів");
            TeacherRepo.AddToDb(t7);
            Teacher t8 = TeacherRepo.CreateTeacher("Сибіль");
            TeacherRepo.AddToDb(t8);
            Teacher t9 = TeacherRepo.CreateTeacher("Літинський");
            TeacherRepo.AddToDb(t9);
            Teacher t10 = TeacherRepo.CreateTeacher("Клакович");
            TeacherRepo.AddToDb(t10);
            Teacher t11 = TeacherRepo.CreateTeacher("Галамага");
            TeacherRepo.AddToDb(t11);
            Teacher t12 = TeacherRepo.CreateTeacher("Дреботій");
            TeacherRepo.AddToDb(t12);
            Teacher t13 = TeacherRepo.CreateTeacher("Заболоцький");
            TeacherRepo.AddToDb(t13);
            Teacher t14 = TeacherRepo.CreateTeacher("Малець");
            TeacherRepo.AddToDb(t14);
            Teacher t15 = TeacherRepo.CreateTeacher("Кулешник");
            TeacherRepo.AddToDb(t15);
            Teacher t16 = TeacherRepo.CreateTeacher("Прядко");
            TeacherRepo.AddToDb(t16);
            Teacher t17 = TeacherRepo.CreateTeacher("Гошко");
            TeacherRepo.AddToDb(t17);
            Teacher t18 = TeacherRepo.CreateTeacher("Пасічник");
            TeacherRepo.AddToDb(t18);
            Teacher t19 = TeacherRepo.CreateTeacher("Христіянин");
            TeacherRepo.AddToDb(t19);
            Teacher t20 = TeacherRepo.CreateTeacher("Бернакевич");
            TeacherRepo.AddToDb(t20);
            Teacher t21 = TeacherRepo.CreateTeacher("Глова");
            TeacherRepo.AddToDb(t21);
            Teacher t22 = TeacherRepo.CreateTeacher("Христіянин");
            TeacherRepo.AddToDb(t22);
            Teacher t23 = TeacherRepo.CreateTeacher("Музичук");
            TeacherRepo.AddToDb(t23);
            Teacher t24 = TeacherRepo.CreateTeacher("Коренівська");
            TeacherRepo.AddToDb(t24);
            Teacher t25 = TeacherRepo.CreateTeacher("Щербина");
            TeacherRepo.AddToDb(t25);
            Teacher t26 = TeacherRepo.CreateTeacher("Мрака");
            TeacherRepo.AddToDb(t26);
            Teacher t27 = TeacherRepo.CreateTeacher("Калиняк");
            TeacherRepo.AddToDb(t27);
            Teacher t28 = TeacherRepo.CreateTeacher("Когут");
            TeacherRepo.AddToDb(t28);
            Teacher t29 = TeacherRepo.CreateTeacher("Нобіс");
            TeacherRepo.AddToDb(t29);
            Teacher t30 = TeacherRepo.CreateTeacher("Вовк");
            TeacherRepo.AddToDb(t30);
            Teacher t31 = TeacherRepo.CreateTeacher("Вовк");
            TeacherRepo.AddToDb(t31);
            Teacher t32 = TeacherRepo.CreateTeacher("Колос");
            TeacherRepo.AddToDb(t32);
            Teacher t33 = TeacherRepo.CreateTeacher("Шинкаренко");
            TeacherRepo.AddToDb(t33);
            Teacher t34 = TeacherRepo.CreateTeacher("Остапов");
            TeacherRepo.AddToDb(t34);
            Teacher t35 = TeacherRepo.CreateTeacher("Коркуна");
            TeacherRepo.AddToDb(t35);
            Teacher t36 = TeacherRepo.CreateTeacher("Олійник");
            TeacherRepo.AddToDb(t36);
            Teacher t37 = TeacherRepo.CreateTeacher("Тополюк");
            TeacherRepo.AddToDb(t37);
            Teacher t38 = TeacherRepo.CreateTeacher("Чирун");
            TeacherRepo.AddToDb(t38);

        }
        public static void GenerateSubjects()
        {
            // subjects
            Subject s1 = SubjectRepo.CreateSubject("ТЕОРІЯ АЛГОРИТ.", ClassType.Lecture);
            SubjectRepo.AddToDb(s1);
            Subject s2 = SubjectRepo.CreateSubject("ТЕОРІЯ АЛГОРИТ.", ClassType.Computer);
            SubjectRepo.AddToDb(s2);
            Subject s3 = SubjectRepo.CreateSubject("КОМП. ІНФ. мережі", ClassType.Lecture);
            SubjectRepo.AddToDb(s3);
            Subject s4 = SubjectRepo.CreateSubject("КОМП. ІНФ. мережі", ClassType.Computer);
            SubjectRepo.AddToDb(s4);
            Subject s5 = SubjectRepo.CreateSubject("Програмування", ClassType.Lecture);
            SubjectRepo.AddToDb(s5);
            Subject s6 = SubjectRepo.CreateSubject("Програмування", ClassType.Computer);
            SubjectRepo.AddToDb(s6);
            Subject s7 = SubjectRepo.CreateSubject("БД ТА ІС", ClassType.Lecture);
            SubjectRepo.AddToDb(s7);
            Subject s8 = SubjectRepo.CreateSubject("БД ТА ІС", ClassType.Computer);
            SubjectRepo.AddToDb(s8);
            Subject s9 = SubjectRepo.CreateSubject("ВИР. ПРАК.(обч.)", ClassType.Computer);
            SubjectRepo.AddToDb(s9);
            Subject s10 = SubjectRepo.CreateSubject("ТІМС", ClassType.Lecture);
            SubjectRepo.AddToDb(s10);
            Subject s11 = SubjectRepo.CreateSubject("ТІМС", ClassType.Ordinary);
            SubjectRepo.AddToDb(s11);
            Subject s12 = SubjectRepo.CreateSubject("АРХ. ОБЧ. СИСТ", ClassType.Lecture);
            SubjectRepo.AddToDb(s12);
            Subject s13 = SubjectRepo.CreateSubject("АРХ. ОБЧ. СИСТ", ClassType.Computer);
            SubjectRepo.AddToDb(s13);
            Subject s14 = SubjectRepo.CreateSubject("АЛГОРИТМИ І СТРУКТУРИ ДАНИХ", ClassType.Lecture);
            SubjectRepo.AddToDb(s14);
            Subject s15 = SubjectRepo.CreateSubject("АЛГОРИТМИ І СТРУКТУРИ ДАНИХ", ClassType.Computer);
            SubjectRepo.AddToDb(s15);
            Subject s16 = SubjectRepo.CreateSubject("НАВЧАЛЬНА ПРАКТИКА", ClassType.Computer);
            SubjectRepo.AddToDb(s16);
            Subject s17 = SubjectRepo.CreateSubject("МАТЕМАТИЧНИЙ АНАЛІЗ", ClassType.Lecture);
            SubjectRepo.AddToDb(s17);
            Subject s18 = SubjectRepo.CreateSubject("МАТЕМАТИЧНИЙ АНАЛІЗ", ClassType.Ordinary);
            SubjectRepo.AddToDb(s18);
            Subject s19 = SubjectRepo.CreateSubject("ДИСКРЕТНА МАТЕМАТИКА", ClassType.Lecture);
            SubjectRepo.AddToDb(s19);
            Subject s20 = SubjectRepo.CreateSubject("ДИСКРЕТНА МАТЕМАТИКА", ClassType.Ordinary);
            SubjectRepo.AddToDb(s20);
            Subject s21 = SubjectRepo.CreateSubject("ІСТОРІЯ УКРАЇНИ", ClassType.Lecture);
            SubjectRepo.AddToDb(s21);
            Subject s22 = SubjectRepo.CreateSubject("ІСТОРІЯ УКРАЇНИ", ClassType.Ordinary);
            SubjectRepo.AddToDb(s22);
            Subject s23 = SubjectRepo.CreateSubject("(ДВ) ПРИКЛАДНЕ ПРОГР.НА NODEJS", ClassType.Computer);
            SubjectRepo.AddToDb(s23);
            Subject s24 = SubjectRepo.CreateSubject("СИСТЕМИ ШТУЧНОГО ІНТЕЛЕКТУ", ClassType.Lecture);
            SubjectRepo.AddToDb(s24);
            Subject s25 = SubjectRepo.CreateSubject("СИСТЕМИ ШТУЧНОГО ІНТЕЛЕКТУ", ClassType.Computer);
            SubjectRepo.AddToDb(s25);
            Subject s26 = SubjectRepo.CreateSubject("(ДВ) ПРОГР. МОБ. ПЛАТФ", ClassType.Computer);
            SubjectRepo.AddToDb(s26);
            Subject s27 = SubjectRepo.CreateSubject("Методи оптим", ClassType.Lecture);
            SubjectRepo.AddToDb(s27);
            Subject s28 = SubjectRepo.CreateSubject("Методи оптим", ClassType.Computer);
            SubjectRepo.AddToDb(s28);
            Subject s29 = SubjectRepo.CreateSubject("(ДВ) ЦИФРОВА.ОБР.ЗОБР.", ClassType.Computer);
            SubjectRepo.AddToDb(s29);
            Subject s30 = SubjectRepo.CreateSubject("Програмна інженерія", ClassType.Lecture);
            SubjectRepo.AddToDb(s30);
            Subject s31 = SubjectRepo.CreateSubject("Програмна інженерія", ClassType.Computer);
            SubjectRepo.AddToDb(s31);
            Subject s32 = SubjectRepo.CreateSubject("МЕТОДИ КОМП’ЮТЕРНИХ ОБЧИСЛЕНЬ", ClassType.Lecture);
            SubjectRepo.AddToDb(s32);
            Subject s33 = SubjectRepo.CreateSubject("МЕТОДИ КОМП’ЮТЕРНИХ ОБЧИСЛЕНЬ", ClassType.Computer);
            SubjectRepo.AddToDb(s33);

        }
        public static void GenerateGroupSubjects()
        {
            // GroupSubject

            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 12; j++)
                {
                    GroupSubject gs = GroupSubjectRepo.CreateGroupSubject(i, j, 60);
                    GroupSubjectRepo.AddToDb(gs);
                }
            }

            for (int i = 4; i < 7; i++)
            {
                for (int j = 12; j < 23; j++)
                {
                    GroupSubject gs = GroupSubjectRepo.CreateGroupSubject(i, j, 60);
                    GroupSubjectRepo.AddToDb(gs);
                }
            }

            for (int i = 7; i < 10; i++)
            {
                for (int j = 23; j < 34; j++)
                {
                    GroupSubject gs = GroupSubjectRepo.CreateGroupSubject(i, j, 60);
                    GroupSubjectRepo.AddToDb(gs);
                }
            }
        }
        public static void GenerateTeacherSubjects()
        {
            // TeacherSubject
            TeacherSubject ts1 = TeacherSubjectRepo.CreateTeacherSubject(1, 11, 300);
            TeacherSubjectRepo.AddToDb(ts1);
            TeacherSubject ts2 = TeacherSubjectRepo.CreateTeacherSubject(2, 11, 300);
            TeacherSubjectRepo.AddToDb(ts2);
            TeacherSubject ts3 = TeacherSubjectRepo.CreateTeacherSubject(3, 10, 300);
            TeacherSubjectRepo.AddToDb(ts3);
            TeacherSubject ts4 = TeacherSubjectRepo.CreateTeacherSubject(4, 3, 300);
            TeacherSubjectRepo.AddToDb(ts4);
            TeacherSubject ts5 = TeacherSubjectRepo.CreateTeacherSubject(4, 4, 300);
            TeacherSubjectRepo.AddToDb(ts5);
            TeacherSubject ts6 = TeacherSubjectRepo.CreateTeacherSubject(5, 4, 300);
            TeacherSubjectRepo.AddToDb(ts6);
            TeacherSubject ts7 = TeacherSubjectRepo.CreateTeacherSubject(5, 8, 300);
            TeacherSubjectRepo.AddToDb(ts7);
            TeacherSubject ts8 = TeacherSubjectRepo.CreateTeacherSubject(6, 6, 300);
            TeacherSubjectRepo.AddToDb(ts8);
            TeacherSubject ts9 = TeacherSubjectRepo.CreateTeacherSubject(7, 2, 300);
            TeacherSubjectRepo.AddToDb(ts9);
            TeacherSubject ts10 = TeacherSubjectRepo.CreateTeacherSubject(7, 8, 300);
            TeacherSubjectRepo.AddToDb(ts10);
            TeacherSubject ts11 = TeacherSubjectRepo.CreateTeacherSubject(8, 1, 300);
            TeacherSubjectRepo.AddToDb(ts11);
            TeacherSubject ts12 = TeacherSubjectRepo.CreateTeacherSubject(9, 7, 300);
            TeacherSubjectRepo.AddToDb(ts12);
            TeacherSubject ts13 = TeacherSubjectRepo.CreateTeacherSubject(10, 5, 300);
            TeacherSubjectRepo.AddToDb(ts13);
            TeacherSubject ts14 = TeacherSubjectRepo.CreateTeacherSubject(10, 6, 300);
            TeacherSubjectRepo.AddToDb(ts14);
            TeacherSubject ts15 = TeacherSubjectRepo.CreateTeacherSubject(11, 9, 300);
            TeacherSubjectRepo.AddToDb(ts15);
            TeacherSubject ts16 = TeacherSubjectRepo.CreateTeacherSubject(12, 9, 300);
            TeacherSubjectRepo.AddToDb(ts16);
            TeacherSubject ts17 = TeacherSubjectRepo.CreateTeacherSubject(12, 6, 300);
            TeacherSubjectRepo.AddToDb(ts17);
            TeacherSubject ts18 = TeacherSubjectRepo.CreateTeacherSubject(13, 4, 300);
            TeacherSubjectRepo.AddToDb(ts18);
            TeacherSubject ts19 = TeacherSubjectRepo.CreateTeacherSubject(13, 8, 300);
            TeacherSubjectRepo.AddToDb(ts19);
            TeacherSubject ts20 = TeacherSubjectRepo.CreateTeacherSubject(14, 8, 300);
            TeacherSubjectRepo.AddToDb(ts20);
            TeacherSubject ts21 = TeacherSubjectRepo.CreateTeacherSubject(6, 9, 300);
            TeacherSubjectRepo.AddToDb(ts21);
            TeacherSubject ts22 = TeacherSubjectRepo.CreateTeacherSubject(15, 13, 300);
            TeacherSubjectRepo.AddToDb(ts22);
            TeacherSubject ts23 = TeacherSubjectRepo.CreateTeacherSubject(16, 20, 300);
            TeacherSubjectRepo.AddToDb(ts23);
            TeacherSubject ts24 = TeacherSubjectRepo.CreateTeacherSubject(17, 15, 300);
            TeacherSubjectRepo.AddToDb(ts24);
            TeacherSubject ts25 = TeacherSubjectRepo.CreateTeacherSubject(18, 15, 300);
            TeacherSubjectRepo.AddToDb(ts25);
            TeacherSubject ts26 = TeacherSubjectRepo.CreateTeacherSubject(19, 18, 300);
            TeacherSubjectRepo.AddToDb(ts26);
            TeacherSubject ts27 = TeacherSubjectRepo.CreateTeacherSubject(20, 16, 300);
            TeacherSubjectRepo.AddToDb(ts27);
            TeacherSubject ts28 = TeacherSubjectRepo.CreateTeacherSubject(21, 6, 300);
            TeacherSubjectRepo.AddToDb(ts28);
            TeacherSubject ts29 = TeacherSubjectRepo.CreateTeacherSubject(21, 16, 300);
            TeacherSubjectRepo.AddToDb(ts29);
            TeacherSubject ts30 = TeacherSubjectRepo.CreateTeacherSubject(23, 5, 300);
            TeacherSubjectRepo.AddToDb(ts30);
            TeacherSubject ts31 = TeacherSubjectRepo.CreateTeacherSubject(23, 6, 300);
            TeacherSubjectRepo.AddToDb(ts31);
            TeacherSubject ts32 = TeacherSubjectRepo.CreateTeacherSubject(25, 19, 300);
            TeacherSubjectRepo.AddToDb(ts32);
            TeacherSubject ts33 = TeacherSubjectRepo.CreateTeacherSubject(26, 21, 300);
            TeacherSubjectRepo.AddToDb(ts33);
            TeacherSubject ts34 = TeacherSubjectRepo.CreateTeacherSubject(26, 22, 300);
            TeacherSubjectRepo.AddToDb(ts34);
            TeacherSubject ts35 = TeacherSubjectRepo.CreateTeacherSubject(27, 22, 300);
            TeacherSubjectRepo.AddToDb(ts35);
            TeacherSubject ts36 = TeacherSubjectRepo.CreateTeacherSubject(28, 22, 300);
            TeacherSubjectRepo.AddToDb(ts36);
            TeacherSubject ts37 = TeacherSubjectRepo.CreateTeacherSubject(18, 23, 300);
            TeacherSubjectRepo.AddToDb(ts37);
            TeacherSubject ts38 = TeacherSubjectRepo.CreateTeacherSubject(29, 23, 300);
            TeacherSubjectRepo.AddToDb(ts38);
            TeacherSubject ts39 = TeacherSubjectRepo.CreateTeacherSubject(32, 24, 300);
            TeacherSubjectRepo.AddToDb(ts39);
            TeacherSubject ts40 = TeacherSubjectRepo.CreateTeacherSubject(32, 25, 300);
            TeacherSubjectRepo.AddToDb(ts40);
            TeacherSubject ts41 = TeacherSubjectRepo.CreateTeacherSubject(16, 25, 300);
            TeacherSubjectRepo.AddToDb(ts41);
            TeacherSubject ts42 = TeacherSubjectRepo.CreateTeacherSubject(20, 26, 300);
            TeacherSubjectRepo.AddToDb(ts42);
            TeacherSubject ts43 = TeacherSubjectRepo.CreateTeacherSubject(30, 26, 300);
            TeacherSubjectRepo.AddToDb(ts43);
            TeacherSubject ts44 = TeacherSubjectRepo.CreateTeacherSubject(36, 27, 300);
            TeacherSubjectRepo.AddToDb(ts44);
            TeacherSubject ts45 = TeacherSubjectRepo.CreateTeacherSubject(35, 28, 300);
            TeacherSubjectRepo.AddToDb(ts45);
            TeacherSubject ts46 = TeacherSubjectRepo.CreateTeacherSubject(2, 29, 300);
            TeacherSubjectRepo.AddToDb(ts46);
            TeacherSubject ts47 = TeacherSubjectRepo.CreateTeacherSubject(23, 30, 300);
            TeacherSubjectRepo.AddToDb(ts47);
            TeacherSubject ts48 = TeacherSubjectRepo.CreateTeacherSubject(23, 31, 300);
            TeacherSubjectRepo.AddToDb(ts48);
            TeacherSubject ts49 = TeacherSubjectRepo.CreateTeacherSubject(11, 31, 300);
            TeacherSubjectRepo.AddToDb(ts49);
            TeacherSubject ts50 = TeacherSubjectRepo.CreateTeacherSubject(21, 31, 300);
            TeacherSubjectRepo.AddToDb(ts50);
            TeacherSubject ts51 = TeacherSubjectRepo.CreateTeacherSubject(33, 32, 300);
            TeacherSubjectRepo.AddToDb(ts51);
            TeacherSubject ts52 = TeacherSubjectRepo.CreateTeacherSubject(18, 33, 300);
            TeacherSubjectRepo.AddToDb(ts52);
            TeacherSubject ts53 = TeacherSubjectRepo.CreateTeacherSubject(34, 33, 300);
            TeacherSubjectRepo.AddToDb(ts53);
        }
    }
}
