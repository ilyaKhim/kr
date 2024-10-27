using CeramicAlloyCalculator.Database;
using CeramicAlloyCalculator.Database.Tables;

namespace CeramicAlloyCalculator.Administrator.MaterialList;

public class LogManager
{
    private readonly DatabaseApplicationContext _dbContext;

    public LogManager(DatabaseApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveLog(LogEntity _logEntity)
    {
        _dbContext.logs.Add(_logEntity);
        _dbContext.SaveChanges();
    }

}