/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { BaseModel } from "./base-model";
import { IBaseModel } from "./i-base-model";
import { IModifiable } from "./i-modifiable";
import { ISoftDeletable } from "./i-soft-deletable";
import { ICreatable } from "./i-creatable";

export class PackageReference extends BaseModel implements IBaseModel, IModifiable, ISoftDeletable, ICreatable {
    packageName: string;
    packageVersion: string;
    includeAssets: boolean;
}
