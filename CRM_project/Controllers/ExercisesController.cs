﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_project.Data;
using CRM_project.Models;

namespace CRM_project.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly CRM_projectContext _context;

        public ExercisesController(CRM_projectContext context)
        {
            _context = context;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            var cRM_projectContext = _context.Exercise.Include(e => e.Classroom).Include(e => e.Group).Include(e => e.Subject).Include(e => e.Teacher);
            return View(await cRM_projectContext.ToListAsync());
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .Include(e => e.Classroom)
                .Include(e => e.Group)
                .Include(e => e.Subject)
                .Include(e => e.Teacher)
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            ViewData["ClassroomID"] = new SelectList(_context.Classroom, "CalssroomId", "CalssroomId");
            ViewData["GroupID"] = new SelectList(_context.Set<Group>(), "GroupId", "GroupId");
            ViewData["SubjectID"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId");
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "TeacherId", "TeacherId");
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseId,SubjectID,TeacherID,ClassroomID,GroupID,Date")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomID"] = new SelectList(_context.Classroom, "CalssroomId", "CalssroomId", exercise.ClassroomID);
            ViewData["GroupID"] = new SelectList(_context.Set<Group>(), "GroupId", "GroupId", exercise.GroupID);
            ViewData["SubjectID"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", exercise.SubjectID);
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "TeacherId", "TeacherId", exercise.TeacherID);
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            ViewData["ClassroomID"] = new SelectList(_context.Classroom, "CalssroomId", "CalssroomId", exercise.ClassroomID);
            ViewData["GroupID"] = new SelectList(_context.Set<Group>(), "GroupId", "GroupId", exercise.GroupID);
            ViewData["SubjectID"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", exercise.SubjectID);
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "TeacherId", "TeacherId", exercise.TeacherID);
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,SubjectID,TeacherID,ClassroomID,GroupID,Date")] Exercise exercise)
        {
            if (id != exercise.ExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseExists(exercise.ExerciseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomID"] = new SelectList(_context.Classroom, "CalssroomId", "CalssroomId", exercise.ClassroomID);
            ViewData["GroupID"] = new SelectList(_context.Set<Group>(), "GroupId", "GroupId", exercise.GroupID);
            ViewData["SubjectID"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", exercise.SubjectID);
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "TeacherId", "TeacherId", exercise.TeacherID);
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .Include(e => e.Classroom)
                .Include(e => e.Group)
                .Include(e => e.Subject)
                .Include(e => e.Teacher)
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise != null)
            {
                _context.Exercise.Remove(exercise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercise.Any(e => e.ExerciseId == id);
        }
    }
}
