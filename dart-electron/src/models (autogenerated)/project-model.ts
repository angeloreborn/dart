/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { BaseModel } from "./base-model";
import { IBaseModel } from "./i-base-model";
import { IModifiable } from "./i-modifiable";
import { ISoftDeletable } from "./i-soft-deletable";
import { ICreatable } from "./i-creatable";
import { IProjectModel } from "./i-project-model";
import { ProjectType } from "./project-type";
import { PackageReference } from "./package-reference";

export class ProjectModel extends BaseModel implements IBaseModel, IModifiable, ISoftDeletable, ICreatable, IProjectModel {
    namespace: string;
    fullPath: string;
    projectType: ProjectType;
    projectReferences: ProjectModel[];
    packageReferences: PackageReference[];
}
