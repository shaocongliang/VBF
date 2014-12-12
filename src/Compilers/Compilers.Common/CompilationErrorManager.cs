﻿// Copyright 2012 Fan Shi
// 
// This file is part of the VBF project.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace VBF.Compilers
{
    public class CompilationErrorManager
    {
        private CompilationErrorInfoCollection m_errorInfoStore;

        public CompilationErrorManager()
        {
            m_errorInfoStore = new CompilationErrorInfoCollection();
        }       

        public void DefineError(int id, int level, CompilationStage stage, string messageTemplate)
        {
            CodeContract.RequiresArgumentInRange(!m_errorInfoStore.Contains(id), "id", "Error id is duplicated");

            var errorInfo = new CompilationErrorInfo(id, level, stage, messageTemplate);
            m_errorInfoStore.Add(errorInfo);
        }

        public CompilationErrorInfo GetErrorInfo(int id)
        {
            return m_errorInfoStore[id];
        }

        public bool ContainsErrorDefinition(int id)
        {
            return m_errorInfoStore.Contains(id);
        }        

        public CompilationErrorList CreateErrorList()
        {
            return new CompilationErrorList(this);
        }
    }
}
