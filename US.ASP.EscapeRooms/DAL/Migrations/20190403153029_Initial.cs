using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace US.ASP.EscapeRooms.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    OpenFrom = table.Column<int>(nullable: false),
                    OpenTo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "Name", "OpenFrom", "OpenTo" },
                values: new object[,]
                {
                    { 1, @"Another year at the Wizarding School brings with it new challenges. You have been summoned by the headmaster to find a most precious artefact which has been lost for many decades.
                Its whereabouts unknown, your search leads you to a mysterious part of the castle where no one has ventured in years. You feel danger lurking around every dark corner...

                You and your friends must face a great evil in order to complete your mission. The monster guarding the chamber will be like nothing you’ve faced before.
                Pick up your wands, remember your spells and find your courage, you will need all of them for the challenges that lie ahead!", "Wizarding School: Fang of the Serpent", 9, 17 },
                    { 2, @"Knightsbane city is under attack. Dr. Drakker, the evil genius has escaped from prison and has sworn vengeance on his nemesis, the city’s hero, Blackwing. He has released all of the other prisoners from Alistair Penitentiary and has tracked down the location of Blackwing’s secret cave. Using his engineering skills he has set numerous traps for the hero by planting various devices in his cave only to be entertained by his torment. 

                The fallen hero of Knightsbane city must now face his greatest challenge yet by defeating Dr. Drakker once more and bringing him to justice. As Blackwing’s sidekicks you will need to help him throughout all the mad puzzles prepared by his arch nemesis and escape the cave before the time runs out!", "Blackwing’s Cave", 14, 22 },
                    { 3, @"21’st of October 1891, London. Newspapers announce the death of one of the greatest detectives that has ever lived… Sherlock was working for the past months on the most important case in his career. He had become isolated and he had lost touch with the outside world. 

                He was last seen on a dark alley in Westminster…the next day, a body was brought in to the King’s Hill Hospital morgue matching his description. It is your duty now, as Sherlock’s faithful assistant, to go into his office and unravel the mystery surrounding his death by solving his last case, but be careful, the one behind Sherlock’s murder may now be after you…", "Sherlock’s Despair", 12, 21 },
                    { 4, @"With the expansion of the human race on other planets, an oppressive regime has risen to power and instated a dictatorship on the Colonial Republic, the dreaded Alpha One faction. You and your team are part of a rebel alliance trying to overthrow the regime and reinstate democracy. 

                A massive assault will take place on the Horizon Alpha space station, serving as the Alpha One headquarters, which aims to destroy it, thus sparking a revolution on all planets. Your mission is to infiltrate the station and deactivate the shields in time so that the assault may be successful. 

                Without the shields down, the entire offensive will become a suicide mission. Good luck, you are the galaxy’s only hope!", "War on Horizon Alpha", 7, 20 },
                    { 5, @"Dr. Vladimir Knifesblade, your friendly university professor seemed like a really nice person. You and your friends always enjoyed his lectures on human anatomy so when he invited you all to his house for a dinner party you never hesitated and accepted the invitation. 

                Once you arrived at his house, though, the door was open so you went it. Nobody seemed to be home so you went down into the basement hearing some weird noises… 

                The door slammed shut behind you and there was no way to move but forward…into the Doctor’s secret laboratory, where it looks like your group might be on the menu…", "Butcher’s Lair", 9, 19 },
                    { 6, @"You are part of a gang of street racers planning a major heist in New York City. Your goal is to hit the 5 major banks in Manhattan in one night, under the cover of an illegal street race where you will be participating with two of your tuned up cars. 

                Everything was set for tonight but all your plans went haywire when one of your rival gangs broke into your garage, stole one of your cars and wrecked the other one. 

                Now you have only one hour to fix the engine of your broken car, find the car park where they have taken you second car and steal it back and then make it in time to the race and finish the job. Do you think your crew has what it takes?", "Heist Plan", 11, 21 },
                    { 7, @"From the depths of the sea a ship rises with a skeletal figure spearheading its bow, striking fear into the hearts of the bravest of sailors. The dreaded ship, The Flying Dutchman makes sail once again, led by its fierce captain. 

                Davy Jones once was a man, but he was cursed by the woman he loved to roam the seas and ferry the souls of the damned to the other side for eternity. A most precious artifact has been stolen from his ship, and now he wants it back. 

                You were one of the pirates that stole from Jones’ locker, but you were left behind when the Dutchman’s crew discovered you. Now you must find your way within the ship and manage to escape before the time runs out and you become part of Davy Jones’ undead crew... forever!", "The Flying Dutchman", 10, 23 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
