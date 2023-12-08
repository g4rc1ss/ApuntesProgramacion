using MapperlyLibrary.ClassToMap;
using MapperlyLibrary.Profiles;

var _mapperly = new MapperlyProfile();

var chatDTO = _mapperly.ToChatDTO(ClassFake.ChatClass);

var chatsDTO = ClassFake.ChatEntityList.Select(x => _mapperly.ToChatDTO(x));

foreach (var chat in chatsDTO)
{
    Console.WriteLine(chat.Id);
}
