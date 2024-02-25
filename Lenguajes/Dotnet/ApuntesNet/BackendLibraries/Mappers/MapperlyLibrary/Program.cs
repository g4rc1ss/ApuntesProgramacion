using MapperlyLibrary.ClassToMap;
using MapperlyLibrary.Profiles;

var mapperly = new MapperlyProfile();

var chatDTO = mapperly.ToChatDTO(ClassFake.chatClass);

var chatsDTO = ClassFake.chatEntityList.Select(mapperly.ToChatDTO);

foreach (var chat in chatsDTO)
{
    Console.WriteLine(chat.Id);
}
