using System;
using System.Reflection.Emit;
using System.Xml.Linq;
using static my_game.Program;

namespace my_game
{
    internal class Program
    {
        static Player player = new Player();//플레이어 instans

        static void Main(string[] args)
        {

            bool running = true;//반복문을 멈출수있게 해주는 스위치

            player.stat();

            while (running)
            {
                Console.Clear();

                Console.WriteLine("스파르타 마을의 오신것을 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할수있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 선택해주세요. ");


                string input = Console.ReadLine();

                Console.WriteLine();

                switch (input)
                {

                    case "1":
                        Console.Clear();
                        ShowStatus();
                        break;
                    case "2":
                        Console.Clear();
                        Inventory();
                        break;
                    case "3":
                        Console.Clear();
                        store();
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.\n");
                        Console.ReadLine();
                        break;
                }
            }

        }


        public class Player
        {
            public string Job { get; set; }
            public string Name { get; set; }
            public int Level { get; set; }
            public int Hp { get; set; }
            public int Attack { get; set; }
            public int Def { get; set; }
            public int Gold { get; set; }


            public bool armoring = false;//수련자 갑옷           
            public bool spartaarmor = false;//스파르타의 갑옷            
            public bool aex = false;//청동 도끼            
            public bool armor = false;//무쇠갑옷
            public bool spear = false;//스파르타의창
            public bool sword = false;//낡은검




            public void stat()
            {
                Name = "용사";
                Job = "전사";
                Level = 1;
                Hp = 100;
                Attack = 10;
                Def = 5;
                Gold = 500000;
            }
        }
        static public void ShowStatus() //
        {

            Console.WriteLine("\n[===== 상태 보기 =====]");
            Console.WriteLine($"이름: {player.Name}");
            Console.WriteLine($"직업: {player.Job}");
            Console.WriteLine($"레벨: {player.Level}");
            Console.WriteLine($"체력: {player.Hp}");
            Console.WriteLine($"공격력: {player.Attack}");
            Console.WriteLine($"방어력: {player.Def}");
            Console.WriteLine($"소지금: {player.Gold} G");
            Console.WriteLine("========================\n");




            string input = "";

            while (input != "0")
            {
                Console.WriteLine("0. 메인으로 돌아가기");
                input = Console.ReadLine();

                if (input != "0")
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }




        static public void Inventory()
        {
            Console.WriteLine("=== 아이템 목록 ===");
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 돌아가기");
            Console.Write("\n원하는 행동을 선택하세요: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Armorpack();
                    break;

                case "0":
                    Console.WriteLine("메인으로 돌아갑니다.");
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }


        }





        static public void Armorpack()
        {
            Console.Clear();
            Console.WriteLine("[아이템 목록]");

            // 항상 보이는 기존 아이템
            if (player.armor)
                Console.WriteLine("1. [E]무쇠 갑옷 | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.");
            else
                Console.WriteLine("1. 무쇠 갑옷 | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.");

            if (player.spear)
                Console.WriteLine("2. [E]스파르타의 창 | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.");
            else
                Console.WriteLine("2. 스파르타의 창 | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.");

            if (player.sword)
                Console.WriteLine("3. [E]낡은 검 | 공격력 +2 | 쉽게 볼 수 있는 낡은 검입니다.");
            else
                Console.WriteLine("3. 낡은 검 | 공격력 +2 | 쉽게 볼 수 있는 낡은 검입니다.");

            // 구매해야만 보이는 아이템들
            if (player.armoring)
            {
                if (player.armoring == true)
                    Console.WriteLine("4. [E]수련자 갑옷 | 방어력 +5 | 수련에 도움을 주는 갑옷입니다.");
                else
                    Console.WriteLine("4. 수련자 갑옷 | 방어력 +5 | 수련에 도움을 주는 갑옷입니다.");
            }

            if (player.spartaarmor)
            {
                if (player.spartaarmor == true)
                    Console.WriteLine("5. [E]스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
                else
                    Console.WriteLine("5. 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
            }

            if (player.aex)
            {
                if (player.aex == true)
                    Console.WriteLine("6. [E]청동 도끼 | 공격력 +5 | 어디선가 사용됐던거 같은 도끼입니다.");
                else
                    Console.WriteLine("6. 청동 도끼 | 공격력 +5 | 어디선가 사용됐던거 같은 도끼입니다.");
            }

            Console.WriteLine("\n장착하거나 해제할 아이템 번호를 입력하거나\n0을 눌러 메인으로 돌아갑니다.");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (player.armor == false)
                    {
                        player.armor = true;
                        player.Def += 5;
                        Console.WriteLine("무쇠 갑옷을 장착했습니다.");
                    }
                    else
                    {
                        player.armor = false;
                        player.Def -= 5;
                        Console.WriteLine("무쇠 갑옷을 해제했습니다.");
                    }
                    break;

                case "2":
                    if (player.spear == false)
                    {
                        player.spear = true;
                        player.Attack += 7;
                        Console.WriteLine("스파르타의 창을 장착했습니다.");
                    }
                    else
                    {
                        player.spear = false;
                        player.Attack -= 7;
                        Console.WriteLine("스파르타의 창을 해제했습니다.");
                    }
                    break;

                case "3":
                    if (player.sword == false)
                    {
                        player.sword = true;
                        player.Attack += 2;
                        Console.WriteLine("낡은 검을 장착했습니다.");
                    }
                    else
                    {
                        player.sword = false;
                        player.Attack -= 2;
                        Console.WriteLine("낡은 검을 해제했습니다.");
                    }
                    break;

                case "4":
                    if (player.armoring)
                    {
                        if (player.armoring == false)
                        {
                            player.armoring = true;
                            player.Def += 5;
                            Console.WriteLine("수련자 갑옷을 장착했습니다.");
                        }
                        else
                        {
                            player.armoring = false;
                            player.Def -= 5;
                            Console.WriteLine("수련자 갑옷을 해제했습니다.");
                        }
                    }
                    else
                        Console.WriteLine("수련자 갑옷을 소유하고 있지 않습니다.");
                    break;

                case "5":
                    if (player.spartaarmor)
                    {
                        if (player.spartaarmor == false)
                        {
                            player.spartaarmor = true;
                            player.Def += 15;
                            Console.WriteLine("스파르타의 갑옷을 장착했습니다.");
                        }
                        else
                        {
                            player.spartaarmor = false;
                            player.Def -= 15;
                            Console.WriteLine("스파르타의 갑옷을 해제했습니다.");
                        }
                    }
                    else
                        Console.WriteLine("스파르타의 갑옷을 소유하고 있지 않습니다.");
                    break;

                case "6":
                    if (player.aex)
                    {
                        if (player.aex == false)
                        {
                            player.aex = true;
                            player.Attack += 5;
                            Console.WriteLine("청동 도끼를 장착했습니다.");
                        }
                        else
                        {
                            player.aex = false;
                            player.Attack -= 5;
                            Console.WriteLine("청동 도끼를 해제했습니다.");
                        }
                    }
                    else
                        Console.WriteLine("청동 도끼를 소유하고 있지 않습니다.");
                    break;

                case "0":
                    Console.WriteLine("메인으로 돌아갑니다.");
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

            Console.WriteLine("\n계속하려면 엔터를 눌러주세요...");
            Console.ReadLine();
            Armorpack();
        }
        static public void store()
        {
            Console.WriteLine($"[보유골드]\n{player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("- 수련자 갑옷      | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.                   |  1000 G");
            Console.WriteLine("- 무쇠갑옷         | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.               |  1500 G");
            Console.WriteLine("- 스파르타의 갑옷  | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  3500 G");
            Console.WriteLine("- 낡은 검          | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.                  |  600  G");
            Console.WriteLine("- 청동 도끼        | 공격력 +5  | 어디선가 사용됐던거 같은 도끼입니다.             |  1500 G");
            Console.WriteLine("- 스파르타의 창    | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다.  |  6000 G");
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");



            string input = Console.ReadLine();

            switch (input)
            {

                case "1":
                    store2();
                    break;

                case "0":
                    Console.WriteLine("메인으로 돌아갑니다.");
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");                   
                    break;
                    
            }
            
        }
        static public void store2()
        {
            Console.Clear();
            Console.WriteLine($"[보유골드]\n{player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"1. 수련자 갑옷      | 방어력 +5  | 1000 G {(player.armoring ? "| (구매완료)" : "")}");
            Console.WriteLine($"2. 무쇠갑옷         | 방어력 +9  | 1500 G {(player.armor ? "| (구매완료)" : "")}");
            Console.WriteLine($"3. 스파르타의 갑옷  | 방어력 +15 | 3500 G {(player.spartaarmor ? "| (구매완료)" : "")}");
            Console.WriteLine($"4. 낡은 검          | 공격력 +2  | 600 G  {(player.sword ? "| (구매완료)" : "")}");
            Console.WriteLine($"5. 청동 도끼        | 공격력 +5  | 1500 G {(player.aex ? "| (구매완료)" : "")}");
            Console.WriteLine($"6. 스파르타의 창    | 공격력 +7  | 6000 G {(player.spear ? "| (구매완료)" : "")}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.WriteLine();

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (player.armoring)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (player.Gold >= 1000)
                    {
                        player.Gold -= 1000;
                        player.armoring = true;
                        Console.WriteLine("수련자 갑옷을 구매하였습니다!");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    break;

                case "2":
                    if (player.armor)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (player.Gold >= 1500)
                    {
                        player.Gold -= 1500;
                        player.armor = true;
                        Console.WriteLine("무쇠갑옷을 구매하였습니다!");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    break;

                case "3":
                    if (player.spartaarmor)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (player.Gold >= 3500)
                    {
                        player.Gold -= 3500;
                        player.spartaarmor = true;
                        Console.WriteLine("스파르타의 갑옷을 구매하였습니다!");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    break;

                case "4":
                    if (player.sword)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (player.Gold >= 600)
                    {
                        player.Gold -= 600;
                        player.sword = true;
                        Console.WriteLine("낡은 검을 구매하였습니다!");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    break;

                case "5":
                    if (player.aex)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (player.Gold >= 1500)
                    {
                        player.Gold -= 1500;
                        player.aex = true;
                        Console.WriteLine("청동 도끼를 구매하였습니다!");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    break;

                case "6":
                    if (player.spear)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (player.Gold >= 6000)
                    {
                        player.Gold -= 6000;
                        player.spear = true;
                        Console.WriteLine("스파르타의 창을 구매하였습니다!");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    break;

                case "0":
                    Console.WriteLine("상점에서 나갑니다.");
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

            Console.WriteLine("\n계속하려면 엔터를 눌러주세요...");
            Console.ReadLine();
            store2(); // 반복해서 상점 열기
        }
    }
}





