using MotionRepoServer.Models;

namespace MotionRepoServer.Data;

public static class AvatarSampleData
{
    public static List<Avatar> GetSampleAvatars()
    {
        return new List<Avatar>
        {
            new Avatar("MaleBot.glb", "Male Bot", "A male robot avatar", "Male", new[] { "Robotics", "Technology" }) 
            { 
                Id = Guid.Parse("904d91dc-f6cf-4da6-a0cc-becdd51ac64f") 
            },
            new Avatar("FemaleBot.glb", "Female Bot", "A female robot avatar", "Female", new[] { "Robotics", "Technology" }) 
            { 
                Id = Guid.Parse("98fd82e0-c4a6-46cf-9b60-28150eed3ffd") 
            },
            new Avatar("Ninja.glb", "Shadow Ninja", "A stealthy ninja warrior avatar", "Male", new[] { "Fantasy", "Stealth" }) 
            { 
                Id = Guid.Parse("e66fb150-f748-4dfa-a4cb-b12c8ba1ea25") 
            },
            new Avatar("Maria.glb", "Maria", "A friendly female character avatar", "Female", new[] { "Realistic", "Casual" }) 
            { 
                Id = Guid.Parse("e32a46ec-6546-4f44-a517-1b2f6c960827") 
            },
            new Avatar("Knight.glb", "Sir Galahad", "A noble medieval knight in shining armor", "Male", new[] { "Fantasy", "Historical", "Medieval" }),
            new Avatar("Wizard.glb", "Merlin", "A wise old wizard with magical powers", "Male", new[] { "Fantasy", "Magic" }),
            new Avatar("Elf.glb", "Elara", "An elegant elven archer", "Female", new[] { "Fantasy", "Archery" }),
            new Avatar("Pirate.glb", "Captain Blackbeard", "A fearsome pirate captain", "Male", new[] { "Adventure", "Historical", "Maritime" }),
            new Avatar("Astronaut.glb", "Commander Nova", "A space explorer in advanced suit", "Female", new[] { "Sci-Fi", "Space", "Technology" }),
            new Avatar("Cyborg.glb", "Unit-X7", "A half-human, half-machine warrior", "Male", new[] { "Sci-Fi", "Technology", "Cyberpunk" }),
            new Avatar("Samurai.glb", "Akira", "A honorable Japanese warrior", "Male", new[] { "Historical", "Japanese", "Warrior" }),
            new Avatar("Viking.glb", "Freydis", "A fierce Norse warrior maiden", "Female", new[] { "Historical", "Norse", "Warrior" }),
            new Avatar("Mage.glb", "Seraphina", "A powerful sorceress of light magic", "Female", new[] { "Fantasy", "Magic", "Light" }),
            new Avatar("Soldier.glb", "Sergeant Steel", "A modern military operative", "Male", new[] { "Military", "Modern", "Combat" }),
            new Avatar("Medic.glb", "Dr. Hope", "A battlefield medic and healer", "Female", new[] { "Military", "Medical", "Support" }),
            new Avatar("Alien.glb", "Zyx-9", "An extraterrestrial being from distant worlds", "Non-Binary", new[] { "Sci-Fi", "Alien", "Exotic" }),
            new Avatar("Barbarian.glb", "Thorgar", "A mighty warrior from the frozen north", "Male", new[] { "Fantasy", "Warrior", "Tribal" }),
            new Avatar("Assassin.glb", "Shadow", "A deadly silent killer", "Female", new[] { "Stealth", "Combat", "Dark" }),
            new Avatar("Engineer.glb", "Gearhead", "A tech-savvy mechanical expert", "Male", new[] { "Industrial", "Technology", "Engineering" }),
            new Avatar("Dancer.glb", "Luna", "A graceful performer and entertainer", "Female", new[] { "Artistic", "Performance", "Entertainment" })
        };
    }
}