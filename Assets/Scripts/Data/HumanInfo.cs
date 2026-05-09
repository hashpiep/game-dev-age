using UnityEngine;

public class HumanInfo
{
    private string firstName;
    private string lastName;
    private Sex sex;
    public string FirstName { get { return firstName; } }
    public string LastName { get { return lastName; } }
    public Sex Sex { get { return sex; } }
    public HumanInfo(string firstName, string lastName, Sex sex)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.sex = sex;
    }
}
public enum Sex 
{ 
    Male = 0,
    Female = 1
}
