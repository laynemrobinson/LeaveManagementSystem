using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveTypes;

public class LeaveTypeService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypeService
{
    public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes()
    {
        var data = await _context.LeaveTypes.ToListAsync();

        // *** Without AutoMapper
        //var viewData = data.Select(q => new IndexVM
        //{
        //    Id = q.Id,
        //    Name = q.Name,
        //    NumberOfDays = q.NumberOfDays
        //});

        // *** With AutoMapper
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

        return viewData;
    }

    public async Task<T> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }

    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(name.ToLower()));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(leaveTypeEdit.Name.ToLower()) && q.Id != leaveTypeEdit.Id);
    }

    public async Task<bool> DaysExceedMaximum(int leaveTypeId, int days)
    {
        var leaveType = await _context.LeaveTypes.FindAsync(leaveTypeId);
        return leaveType.NumberOfDays < days;
    }
}
