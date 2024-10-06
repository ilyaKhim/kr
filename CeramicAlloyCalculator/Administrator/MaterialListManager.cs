using CeramicAlloyCalculator.Database;
using CeramicAlloyCalculator.Database.Tables;

namespace CeramicAlloyCalculator.Administrator.MaterialList;

public class MaterialListManager
{
    private readonly DatabaseApplicationContext _dbContext;

    public MaterialListManager(DatabaseApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveMaterial(MaterialEntity materialEntity)
    {
        if (materialEntity.id != null) {
            _dbContext.materials.Update(materialEntity);
        } else {
            _dbContext.materials.Add(materialEntity);
        }

        _dbContext.SaveChanges();

    }

    public List<MaterialEntity> GetMaterials()
    {
        return _dbContext.materials.ToList();
    }

    public void DeleteMaterial(MaterialEntity material)
    {
        _dbContext.materials.Remove(material);
        _dbContext.SaveChanges();
    }
}