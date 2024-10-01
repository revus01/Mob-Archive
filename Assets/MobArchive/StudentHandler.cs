using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobArchive
{
    public class StudentHandler : MonoBehaviour
    {
        private List<GameObject> _students;
        
        public StudentHandler(List<GameObject> students)
        {
            _students = students;
        }
        
        

        public void UpdateStudentState()
        {
            
        }
    }
}
