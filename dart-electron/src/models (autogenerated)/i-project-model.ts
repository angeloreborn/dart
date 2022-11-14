/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { ProjectModel } from "./project-model";
import { PackageReference } from "./package-reference";
import { ProjectType } from "./project-type";

export class IProjectModel {
    namespace: string;
    projectReferences: ProjectModel[];
    packageReferences: PackageReference[];
    projectType: ProjectType;
}
