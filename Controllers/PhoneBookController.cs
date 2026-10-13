using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

namespace PhoneBookAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneBookController : ControllerBase
{

    static List<PhoneBookEntry> contacts = new List<PhoneBookEntry>()
    {
        new PhoneBookEntry(){Number="01555999", Name="Jemmy Ned", Address="The Hill"},
        new PhoneBookEntry(){Number="04234390", Name="Mickey Joe", Address="The Street"},
        new PhoneBookEntry(){Number="0915687559", Name="Mary Mack", Address="Over Yonder"}
    };
    public PhoneBookController()
    {
    }


    [HttpGet(Name = "GetPhoneBook")]
    
    public IEnumerable<PhoneBookEntry> Get()
    {
        return contacts;
    }

    [HttpGet("{_name}")]
    
    public IEnumerable<PhoneBookEntry> Get(String _name)
    {
        var records = contacts.Where(p=>p.Name.ToUpper() == _name.ToUpper());
        if (records!=null)
        {
            return records;
        }
        else return null;
    }
  
    [HttpGet("GetByNumber/{_number}")]
    public IEnumerable<PhoneBookEntry> GetByNumber(String _number)
    {
        var records = contacts.Where(p=>p.Number.ToUpper() == _number.ToUpper());
        if (records!=null)
        {
            return records;
        }
        else return null;
    }

    [HttpPost]
    public void AddContact(PhoneBookEntry _contact)
    {
        if (_contact!=null)
        {
            contacts.Add(_contact);
        }
    }

}
