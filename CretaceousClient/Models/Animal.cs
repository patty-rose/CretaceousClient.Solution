using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CretaceousClient.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }

    public static List<Animal> GetAnimals()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }

    //key differences between GetAnimals() and GetDetails(): 1. GetDetails The method will return a singular animal. 2. GetDetails() will take an id. 3. the API call results in a JSOn object as opposed to a JSON array
    public static Animal GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

      return animal;
    }

    public static void Post(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);//converts animal object into JSON 
      var apiCallTask = ApiHelper.Post(jsonAnimal);
    }

    public static void Put(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      var apiCallTask = ApiHelper.Put(animal.AnimalId, jsonAnimal);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}