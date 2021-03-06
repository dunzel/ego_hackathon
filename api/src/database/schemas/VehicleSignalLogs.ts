/**
 * This file is part of the vehicle-booking-api distribution (https://github.com/egodigital/hackathon/api).
 * Copyright (c) e.GO Digital GmbH, Aachen, Germany
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

import * as egoose from '@egodigital/egoose';
import * as mongoose from 'mongoose';


export const SCHEMA: mongoose.SchemaDefinition = {
    creation_time: {
        default: () => egoose.utc().toDate(),
        type: Date,
    },
    name: {
        lowercase: true,
        trim: true,
        type: String,
    },
    new_data: {
        required: false,
        type: mongoose.Schema.Types.Mixed,
    },
    old_data: {
        required: false,
        type: mongoose.Schema.Types.Mixed,
    },
    signal_id: {
        type: String,
    },
    vehicle_id: {
        type: String,
    },
};

export function setupSchema(schema: mongoose.Schema, name: string) {
    schema.index({ name: 1 });
    schema.index({ signal_id: 1 });
    schema.index({ vehicle_id: 1 });
}
