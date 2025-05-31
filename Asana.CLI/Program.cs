using Asana.Library.Models;
using System;

namespace Asana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var toDos = new List<ToDo>();
            var projects = new List<Project>();
            int choiceInt;
            var itemCount = 0;
            var projectItemCount = 0;
            var toDoChoice = 0;
            var projChoice = 0;
            var projToDos = 0;
            do
            {
                Console.WriteLine("Choose a menu option:");
                Console.WriteLine("1. Create a ToDo");
                Console.WriteLine("2. List all ToDos");
                Console.WriteLine("3. List all outstanding ToDos");
                Console.WriteLine("4. Delete a ToDo");
                Console.WriteLine("5. Update a ToDo");
                Console.WriteLine("6. Create a Project");
                Console.WriteLine("7. Delete a Project");
                Console.WriteLine("8. Update a Project");
                Console.WriteLine("9. List all Projects");
                Console.WriteLine("10. List all ToDos in a Given Project");
                Console.WriteLine("11. Exit");

                var choice = Console.ReadLine() ?? "11";

                if (int.TryParse(choice, out choiceInt))
                {
                    switch (choiceInt)
                    {
                        case 1:
                        
                            Console.Write("Name:");
                            var name = Console.ReadLine();
                            Console.Write("Description:");
                            var description = Console.ReadLine();
                            Console.Write("Priority: ");
                            var priority = Console.ReadLine();
                            Console.Write("Project ID: ");
                            var projIdentifier = Convert.ToInt32(Console.ReadLine());

                            toDos.Add(new ToDo { Name = name,
                                Description = description,
                                Priority = priority,
                                IsCompleted = false,
                                Id = ++itemCount,
                                ProjectId = projIdentifier
                            });
                                
                            break;
                        case 2:
                        
                            toDos.ForEach(Console.WriteLine);
                            break;
                        case 3:
                            toDos.Where(t => (t != null) && !(t?.IsCompleted ?? false))
                                .ToList()
                                .ForEach(Console.WriteLine);
                            break;
                        case 4:
                            
                            toDos.ForEach(Console.WriteLine);
                            Console.Write("ToDo to Delete: ");
                            toDoChoice = int.Parse(Console.ReadLine() ?? "0");

                            var reference = toDos.FirstOrDefault(t => t.Id == toDoChoice);
                            if (reference != null)
                            {
                                toDos.Remove(reference);
                            }
                            
                            break;
                        case 5:
                            
                            toDos.ForEach(Console.WriteLine);
                            Console.Write("ToDo to Update: ");
                            toDoChoice = int.Parse(Console.ReadLine() ?? "0");
                            var updateReference = toDos.FirstOrDefault(t => t.Id == toDoChoice);

                            if(updateReference != null)
                            {
                                Console.Write("Name: ");
                                updateReference.Name = Console.ReadLine();
                                Console.Write("Description: ");
                                updateReference.Description = Console.ReadLine();
                                Console.Write("Is Complete? (True or False): ");
                                updateReference.IsCompleted = 
                                bool.Parse(Console.ReadLine());
                                Console.Write("Priority: ");
                                updateReference.Priority = Console.ReadLine();
                                Console.Write("Project ID: ");
                                updateReference.ProjectId = Convert.ToInt32(Console.ReadLine());
                            }
                            
                            break;
                        case 6:
                        
                            Console.Write("Name:");
                            var projectName = Console.ReadLine();
                            Console.Write("Description:");
                            var projectDescription = Console.ReadLine();

                            projects.Add(new Project { Name = projectName,
                                Description = projectDescription,
                                CompletePercent = 0,
                                Id = ++projectItemCount,
                                projToDos = 0
                                    });
                            break;
                        case 7:
                        
                            projects.ForEach(Console.WriteLine);
                            Console.Write("Project to Delete: ");
                            projChoice = int.Parse(Console.ReadLine() ?? "0");

                            var projectReference = projects.FirstOrDefault(t => t.Id == projChoice);
                            if (projectReference != null)
                            {
                                projects.Remove(projectReference);
                            }
                            break;
                        case 8:
                        
                            projects.ForEach(Console.WriteLine);
                            Console.Write("Project to Update: ");
                            projChoice = int.Parse(Console.ReadLine() ?? "0");
                            var updateProjectReference = projects.FirstOrDefault(t => t.Id == projChoice);

                            if(updateProjectReference != null)
                            {
                                Console.Write("Name: ");
                                updateProjectReference.Name = Console.ReadLine();
                                Console.Write("Description: ");
                                updateProjectReference.Description = Console.ReadLine();
                            }
                            break;
                        case 9:
                            foreach (var p in projects)
                            {
                                double totalTodosComplete = 0;
                                double totalTodosIncomplete = 0;
                                
                                foreach( var x in toDos.Where(x => x != null && x.ProjectId == p.Id))
                                    {
                                        if(x?.IsCompleted == true){
                                            totalTodosComplete++;
                                        }
                                        else if(x?.IsCompleted == false){
                                            totalTodosIncomplete++;
                                        }
                                    }
                                
                                p.CompletePercent = ((totalTodosComplete / (totalTodosComplete + totalTodosIncomplete)) * 100);
                            }
                            
                            projects.ForEach(Console.WriteLine);
                            break;
                        case 10:
                           Console.Write("Enter Project ID: ");
                           int project = Convert.ToInt32(Console.ReadLine());
                           foreach (var y in toDos)
                                {
                                    toDos.Where(y => y.ProjectId == project).ToList().ForEach(Console.WriteLine);
                                }
                            break;
                        case 11:
                            break;
                        default:
                            Console.WriteLine("ERROR: Unknown menu selection");
                            break;
                    }
                } else
                {
                    Console.WriteLine($"ERROR: {choice} is not a valid menu selection");
                }

            } while (choiceInt != 11);

        }
    }
}
