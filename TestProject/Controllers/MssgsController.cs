using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MssgsController : ControllerBase
    {
        private readonly TestContext _context;

        public MssgsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Mssgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mssg>>> GetMssg()
        {
            return await _context.Mssg.ToListAsync();
        }

        // GET: api/Mssgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mssg>> GetMssg(int id)
        {
            var mssg = await _context.Mssg.FindAsync(id);

            if (mssg == null)
            {
                return NotFound();
            }

            return mssg;
        }

        // PUT: api/Mssgs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMssg(int id, Mssg mssg)
        {
            if (id != mssg.MssgId)
            {
                return BadRequest();
            }

            _context.Entry(mssg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MssgExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mssgs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        /*public async Task<ActionResult<Mssg>> PostMssg(Mssg mssg)
        {

            _context.Mssg.Add(mssg);
            await _context.SaveChangesAsync();
            return mssg;
        }*/
       public async Task<Mssg> PostMssg(Mssg mssg)
        {
            Contacts oldContact = _context.Contacts.Where(contact => contact.ContactsEmail == mssg.MssgEmail && contact.ContactsTel == mssg.MssgTel).FirstOrDefault();
            if (oldContact == null)
            {
                Contacts contact = new Contacts();
                contact.ContactsName = mssg.MssgName;
                contact.ContactsEmail = mssg.MssgEmail;
                contact.ContactsTel = mssg.MssgTel;

                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                Contacts newContact = _context.Contacts.Where(cont => cont.ContactsEmail == contact.ContactsEmail && cont.ContactsTel == contact.ContactsTel).FirstOrDefault();

                mssg.MssgContact = newContact.ContaccsId;
            }
            else { 
                mssg.MssgContact = oldContact.ContaccsId;
            }
            _context.Mssg.Add(mssg);
            await _context.SaveChangesAsync();
            var record = _context.Mssg.Where(messg => messg.MssgId == mssg.MssgId).FirstOrDefault();
            return record;

        }



        // DELETE: api/Mssgs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mssg>> DeleteMssg(int id)
        {
            var mssg = await _context.Mssg.FindAsync(id);
            if (mssg == null)
            {
                return NotFound();
            }

            _context.Mssg.Remove(mssg);
            await _context.SaveChangesAsync();

            return mssg;
        }

        private bool MssgExists(int id)
        {
            return _context.Mssg.Any(e => e.MssgId == id);
        }
    }
}
