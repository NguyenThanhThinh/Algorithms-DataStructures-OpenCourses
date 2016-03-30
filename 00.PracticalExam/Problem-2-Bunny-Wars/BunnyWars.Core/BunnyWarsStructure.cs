namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        OrderedDictionary<string, Bunny> bunnies = new OrderedDictionary<string, Bunny>();

        OrderedMultiDictionary<int, Bunny> teams = new OrderedMultiDictionary<int, Bunny>(true);

        OrderedSet<int> roomsId = new OrderedSet<int>();

        OrderedDictionary<int, Dictionary<string, Bunny>> rooms = new
            OrderedDictionary<int, Dictionary<string, Bunny>>((x, y) => x.CompareTo(y));

        OrderedDictionary<string, Bunny> suffixDict = new OrderedDictionary<string, Bunny>(StringComparer.Ordinal);

        public int BunnyCount => this.bunnies.Count;

        public int RoomCount => this.roomsId.Count;

        public void AddRoom(int roomId)
        {
            if (this.roomsId.Contains(roomId))
            {
                throw new ArgumentException();
            }

            this.roomsId.Add(roomId);
        }

        public void AddBunny(string name, int team, int roomId)
        {
            if (team > 4 || team < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Bunny bunny = new Bunny(name, team, roomId);

            if (!this.bunnies.ContainsKey(name) && this.roomsId.Contains(roomId))
            {
                this.bunnies.Add(name, bunny);
            }
            else
            {
                throw new ArgumentException();
            }

            this.teams.Add(team, bunny);

            if (!this.rooms.ContainsKey(roomId))
            {
                this.rooms[roomId] = new Dictionary<string, Bunny>();
            }

            this.rooms[roomId][name] = bunny;
            var bunnyNameChar = name.ToCharArray();
            Array.Reverse(bunnyNameChar);
            this.suffixDict[string.Join("", bunnyNameChar)] = bunny;
        }

        public void Remove(int roomId)
        {
            if (!this.roomsId.Contains(roomId))
            {
                throw new ArgumentException();
            }
            if (this.rooms.ContainsKey(roomId))
            {
                foreach (var bunny in this.rooms[roomId].Keys)
                {
                    this.bunnies.Remove(bunny);
                    this.suffixDict.Remove(bunny);
                }
            }
            this.roomsId.Remove(roomId);

        }

        public void Next(string bunnyName)
        {
            if (this.bunnies.ContainsKey(bunnyName))
            {
                var bunny = this.bunnies[bunnyName];
                var currentIndex = this.roomsId.IndexOf(bunny.RoomId);
                if (currentIndex + 1 > 4 || this.roomsId.Count == 1)
                {
                    this.bunnies[bunnyName].RoomId = this.roomsId[0];
                }
                else
                {
                    this.bunnies[bunnyName].RoomId = this.roomsId[currentIndex + 1];
                }
                this.rooms[this.roomsId[currentIndex]].Remove(bunnyName);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Previous(string bunnyName)
        {
            if (this.bunnies.ContainsKey(bunnyName))
            {
                var bunny = this.bunnies[bunnyName];
                var currentIndex = this.roomsId.IndexOf(bunny.RoomId);
                if (currentIndex - 1 < 0 || this.roomsId.Count == 1)
                {
                    this.bunnies[bunnyName].RoomId = this.roomsId[this.roomsId.Count - 1];
                }
                else
                {
                    this.bunnies[bunnyName].RoomId = this.roomsId[currentIndex - 1];
                }
                this.rooms[this.roomsId[currentIndex]].Remove(bunnyName);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Detonate(string bunnyName)
        {
            if (this.bunnies.ContainsKey(bunnyName))
            {
                var attacker = this.bunnies[bunnyName];
                var neededRoom = attacker.RoomId;
                //HASHSET

                if (this.rooms.ContainsKey(neededRoom))
                {
                    foreach (var enemy in this.rooms[neededRoom])
                    {
                        var target = this.bunnies[enemy.Key];
                        if (attacker.Team != target.Team)
                        {
                            target.Health -= 30;
                        }
                        if (target.Health <= 0)
                        {
                            attacker.Score++;
                            this.bunnies.Remove(enemy.Key);
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            if (team > 4 || team < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return this.teams[team];
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            char[] charArray = suffix.ToCharArray();
            Array.Reverse(charArray);
            var suffixReversed = string.Join("", charArray);

            return this.suffixDict.Range(suffixReversed, true, suffixReversed + char.MaxValue, true).Values;
        }
    }
}
