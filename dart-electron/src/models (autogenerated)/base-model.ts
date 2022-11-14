/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { IBaseModel } from "./i-base-model";
import { IModifiable } from "./i-modifiable";
import { ISoftDeletable } from "./i-soft-deletable";
import { ICreatable } from "./i-creatable";

export class BaseModel implements IBaseModel, IModifiable, ISoftDeletable, ICreatable {
    id: number;
    guid: string;
    createdDate: Date;
    modifiedDate: Date;
    deleted: boolean;
}
