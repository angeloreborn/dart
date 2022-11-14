/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { IModifiable } from "./i-modifiable";
import { ISoftDeletable } from "./i-soft-deletable";
import { ICreatable } from "./i-creatable";

export interface IBaseModel extends IModifiable, ISoftDeletable, ICreatable {
    id: number;
}
