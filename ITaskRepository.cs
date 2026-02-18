using System.Collections.Generic;

public interface ITaskRepository
{  
     void Save(List<Todotask> tasks);
    List<Todotask> Load();
}