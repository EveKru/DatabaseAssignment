using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class RoleService(RoleRepository roleRepository)
{
    private readonly RoleRepository _roleRepository = roleRepository;


    public RoleEntity CreateRole(string roleName)
    {
        var RoleEntity = _roleRepository.Get(x => x.RoleName == roleName);
        RoleEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });
        return RoleEntity;
    }

    public RoleEntity GetRoleByName(string roleName)
    {
        var RoleEntity = _roleRepository.Get(x => x.RoleName == roleName);
        return RoleEntity;
    }

    public RoleEntity GetRoleById(int id)
    {
        var RoleEntity = _roleRepository.Get(x => x.Id == id);
        return RoleEntity;
    }

    public IEnumerable<RoleEntity> GetAll()
    {
        var roles = _roleRepository.GetAll();
        return roles;
    }

    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        var updated = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
        return updated;
    }

    public void DeleteRole(int id)
    {
        _roleRepository.Delete(x => x.Id == id);
    }


}


