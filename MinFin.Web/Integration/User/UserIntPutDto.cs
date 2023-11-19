using System.Runtime.Serialization;

namespace MinFin.Web.Integration.User;

[DataContract(Namespace = "")]
public class UserIntPutDto
{
    [DataMember(Order = 1)]
    public int Id { get; set; }

    [DataMember(Order = 2)] 
    public string FirstName { get; set; }

    [DataMember(Order = 3)] 
    public string Surname { get; set; }
}